using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Oven;

public class Grindstone : MonoBehaviour, IInterract
{
    [SerializeField] float maxTimerGrind, timerGrind;

    public GameObject timer;
    public GameObject canvas;
    GameObject timerPrefab;

    public enum grindState { Idle, Grinding, DoneGrinding }
    public grindState activeState = grindState.Idle;

    public GameObject ovenObjectHold;

    private void Update()
    {
        switch (activeState)
        {
            case grindState.Idle:

                break;

            case grindState.Grinding:
                timerGrind -= Time.deltaTime;

                if (timerGrind <= 0)
                {
                    //Done with heat
                    activeState = grindState.DoneGrinding;
                }
                break;

            case grindState.DoneGrinding:
                break;
        }
    }

    public void Interract()
    {
        Debug.Log("Grindstone is interracted");

        List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 2).ToList();
        Collider player = hitColliders.Find(c => c.CompareTag("Player"));
        if (player)
        {
            if (activeState == grindState.Idle)
            {
                PlayerGrabbr playr = player.transform.root.GetComponentInChildren<PlayerGrabbr>();
                if (playr.GetGrabbedItem() != null)
                {
                    if (playr.GetGrabbedItem().CompareTag("SwordFull") || playr.GetGrabbedItem().CompareTag("ArmorFull"))
                    {
                        if (playr.GetGrabbedItem().GetComponentInChildren<ISharpPolish>() != null)
                        {
                            timerGrind = maxTimerGrind;
                            CreateTimer();
                            playr.RemoveGrabbedItem();
                            ovenObjectHold = playr.GetGrabbedItem().GetComponent<ISharpPolish>().GetUpgrade();
                            activeState = grindState.Grinding;
                        }
                    }
                }
            }
            else if (activeState == grindState.DoneGrinding)
            {
                PlayerGrabbr playr = player.transform.root.GetComponentInChildren<PlayerGrabbr>();
                GameObject ressource = Instantiate(ovenObjectHold, player.transform.position, Quaternion.identity);
                ovenObjectHold = null;
                activeState = grindState.Idle;
            }
        }
        
    }

    void CreateTimer()
    {
        timerPrefab = Instantiate(timer, new Vector3(420, -200, 0), Quaternion.identity);
        timerPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        timerPrefab.GetComponentInChildren<Timer>().SetDuration((int)timerGrind).OnEnd(() => Debug.Log("Timer ended")).Begin();
        Invoke("RemoveTimer", timerGrind);
    }


    void RemoveTimer()
    {
        Destroy(timerPrefab);
    }
}
