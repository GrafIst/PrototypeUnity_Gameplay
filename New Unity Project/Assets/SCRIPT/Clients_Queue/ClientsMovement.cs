using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ClientsMovement : MonoBehaviour
{

    [SerializeField] float clientSpeed, maxTimeClientWaiting;
    [SerializeField] Transform spotTarget, exitTarget;

    [SerializeField] Animator an;

    public float timeClientWaiting;

    bool isFirst = false;
    bool buyingTrigger;

    //public bool hasPriority;

    public GameObject timer;
    public GameObject canvas;
    GameObject timerPrefab;

    public enum clientState { Walk, MoveTowards, Queuing, Buying, LeavingQueue}

    public clientState activeState = clientState.Walk;

    QueueManager qm;

    public List<GameObject> skin;

    public bool wantSword;

    private void Awake()
    {
        int selectedSkin = Random.Range(0, 3);
        for(int i = 0; i < skin.Count; i++)
        {
            if (selectedSkin != i)
            {
                skin[i].SetActive(false);
            }
        }

        wantSword = Random.Range(1, 3)%2 == 0;

    }


    // Start is called before the first frame update
    void Start()
    {
        clientSpeed = Random.Range(3, 10);
        maxTimeClientWaiting = Random.Range(70,120);
        timeClientWaiting = maxTimeClientWaiting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (activeState)
        {
            case clientState.Walk:
                //Debug.Log("Client is walking");
                transform.position += -transform.up * clientSpeed * Time.deltaTime;
                break;

            case clientState.MoveTowards:
                //Debug.Log("Walking towards queue spot");
                MoveTowards();
                break;

            case clientState.Queuing:
                //Waiting in line
                break;

            case clientState.Buying:
                LookTowards();
                WaitForItem();
                //Debug.Log("Busy buying and waiting");
                break;

            case clientState.LeavingQueue:
                //Debug.Log("Too slow, i'm leaving");
                Leaving();
                break;
        }
    }

    void MoveTowards()
    {
        //an.SetBool("isBusy", false);
        Vector3 posToTarget = spotTarget.position - transform.position;
        transform.position += new Vector3(posToTarget.x, 0, posToTarget.z).normalized * clientSpeed * Time.deltaTime;
        float distPosTOTarget = posToTarget.magnitude;
        if(distPosTOTarget <= 1f)
        {
           //an.SetBool("isBusy", true);
           activeState = !isFirst ? clientState.Queuing : clientState.Buying;
        }
    }


    public void LookTowards()
    {
        //need ref to player

    }

    public void Leaving()
    {
        //Debug.Log("im leaving");
        //an.SetBool("isBusy", false);
        Vector3 posToExit = exitTarget.position - transform.position;
        transform.position += new Vector3(posToExit.x, 0, posToExit.z).normalized * clientSpeed * Time.deltaTime;
        float distPosTOTarget = posToExit.magnitude;
        //Debug.Log(distPosTOTarget);
        if (distPosTOTarget <= 2f)
        {
            activeState = clientState.Walk;
            qm.RemoveClient(this.transform.root.gameObject);
        }
    }

    void WaitForItem()
    {
        timeClientWaiting -= Time.deltaTime;

        if (!buyingTrigger)
        {
            CreateTimer();
            buyingTrigger = true;
        }

        if(timeClientWaiting <= 0)
        {
            activeState = clientState.LeavingQueue;
        }
    }

    public void SetupQueuePosition(Transform targetSpot, int indexSpot, Transform exitSpot, QueueManager _qm)
    {
        qm = _qm;
        if (indexSpot == 0)
        {
            isFirst = true;
            //Debug.Log("Im first !");
        }

        spotTarget = targetSpot;
        exitTarget = exitSpot;
        activeState = clientState.MoveTowards;
    }

    void CreateTimer()
    {
        timerPrefab = Instantiate(timer, new Vector3(-420, 200, 0), Quaternion.identity);
        timerPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        timerPrefab.GetComponentInChildren<Timer>().SetDuration((int)timeClientWaiting).OnEnd(() => Debug.Log("Timer ended")).Begin();
        Invoke("RemoveTimer", timeClientWaiting);
    }


    void RemoveTimer()
    {
        Destroy(timerPrefab);
    }
}
