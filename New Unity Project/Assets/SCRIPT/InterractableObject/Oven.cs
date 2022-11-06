using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ClientsMovement;

public class Oven : MonoBehaviour, IInterract
{
    [SerializeField] float maxTimerCook, timerCook;

    public GameObject timer;
    public GameObject canvas;
    GameObject timerPrefab;

    public bool isHeating;
    public bool doneHeating;

    public enum ovenState { Idle, Heating, DoneHeating }

    public ovenState activeState = ovenState.Idle;

    public GameObject ovenObjectHold;


    // Start is called before the first frame update
    void Start()
    {
        isHeating = false;
        doneHeating = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (activeState)
        {
            case ovenState.Idle:

                break;

            case ovenState.Heating:
                timerCook -= Time.deltaTime;

                if (timerCook <= 0)
                {
                    //Done with heat
                    activeState = ovenState.DoneHeating;
                }
                break;

            case ovenState.DoneHeating:
                break;
        }

    }

    public void Interract()
    {
        Debug.Log("Oven is interracted");
        List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 2).ToList();
        Collider player = hitColliders.Find(c => c.CompareTag("Player"));
        if (player)
        {
            if(activeState == ovenState.Idle){
                PlayerGrabbr playr = player.transform.root.GetComponentInChildren<PlayerGrabbr>();
                if(playr.GetGrabbedItem() != null)
                {
                    if (playr.GetGrabbedItem().GetComponent<IHeat>() != null)
                    {
                        CreateTimer();
                        playr.RemoveGrabbedItem();
                        ovenObjectHold = playr.GetGrabbedItem().GetComponent<IHeat>().Heat();
                        activeState = ovenState.Heating;
                    }
                }
                
            }
            else if(activeState == ovenState.DoneHeating)
            {
                PlayerGrabbr playr = player.transform.root.GetComponentInChildren<PlayerGrabbr>();
                GameObject ressource = Instantiate(ovenObjectHold, player.transform.position, Quaternion.identity);
                ovenObjectHold = null;
                activeState = ovenState.Idle;
            }
        }
    }

    void CreateTimer()
    {
        timerPrefab = Instantiate(timer, new Vector3(-420, -200, 0), Quaternion.identity);
        timerPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        timerPrefab.GetComponentInChildren<Timer>().SetDuration((int)timerCook).OnEnd(() => Debug.Log("Timer ended")).Begin();
        Invoke("RemoveTimer", timerCook);
    }


    void RemoveTimer()
    {
        Destroy(timerPrefab);
    }


}
