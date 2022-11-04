using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientsMovement : MonoBehaviour
{

    [SerializeField] float clientSpeed, maxTimeClientWaiting;
    [SerializeField] Transform spotTarget, exitTarget;

    [SerializeField] Animator an;

    float timeClientWaiting;

    //public bool hasPriority;

    public enum clientState { Walk, MoveTowards, Queuing, Buying, LeavingQueue}

    public clientState activeState = clientState.Walk;

    ClientQueueBehaviour cqb;

    // Start is called before the first frame update
    void Start()
    {
        clientSpeed = Random.Range(3, 10);
        timeClientWaiting = maxTimeClientWaiting;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (activeState)
        {
            case clientState.Walk:
                //Debug.Log("Client is walking");
                transform.position += transform.right * clientSpeed * Time.deltaTime;
                break;

            case clientState.MoveTowards:
                //Debug.Log("Walking towards queue spot");
                MoveTowards();
                break;

            case clientState.Queuing:
                WaitForFreeSpot();
                //Waiting in line
                break;

            case clientState.Buying:
                LookTowards();
                WaitForItem();
                //Debug.Log("Busy buying and waiting");
                break;

            case clientState.LeavingQueue:
                Debug.Log("Too slow, i'm leaving");
                Leaving();
                break;
        }
    }

    void MoveTowards()
    {
        an.SetBool("isBusy", false);
        Vector3 posToTarget = spotTarget.position - transform.position;
        transform.position += new Vector3(posToTarget.x, 0, posToTarget.z).normalized * clientSpeed * Time.deltaTime;
        float distPosTOTarget = posToTarget.magnitude;
        if(distPosTOTarget <= 1f)
        {
            an.SetBool("isBusy", true);

           // activeState = !hasPriority ? clientState.Queuing : clientState.Buying;
        }
    }

    public void SetTarget(Transform target)
    {
        
        activeState = ClientsMovement.clientState.MoveTowards;
        spotTarget = target;
    }

    public void SetExitTarget(Transform target)
    {
        exitTarget = target;
    }

    public void LookTowards()
    {
        //need ref to player
    }

    public void Leaving()
    {
        an.SetBool("isBusy", false);
        Vector3 posToExit = exitTarget.position - transform.position;
        transform.position += new Vector3(posToExit.x, 0, posToExit.z).normalized * clientSpeed * Time.deltaTime;
        float distPosTOTarget = posToExit.magnitude;
        if (distPosTOTarget <= 1f)
        {
            activeState = clientState.Walk;
        }
    }

    void WaitForItem()
    {
        timeClientWaiting -= Time.deltaTime;

        if(timeClientWaiting <= 0)
        {
            activeState = clientState.LeavingQueue;
        }
    }

    void WaitForFreeSpot()
    {

    }

    public void SetClientQueueBehaviour(ClientQueueBehaviour _cqb)
    {
        cqb = _cqb;
    }
}
