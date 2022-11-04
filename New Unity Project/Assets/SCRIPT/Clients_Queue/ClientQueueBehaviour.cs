using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientQueueBehaviour : MonoBehaviour
{
    [SerializeField] ClientsMovement cm;
    [SerializeField] Transform queueSpot;

    QueueManager qm;

    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponentInChildren<ClientsMovement>();
        cm.SetClientQueueBehaviour(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTowardsSpot(Transform spot)
    {
        cm.SetTarget(spot);
    }

    public void LeavingQueue(Transform exitSpot)
    {
        cm.SetExitTarget(exitSpot);
    }

    public void MakeFirst()
    {
        cm.activeState = ClientsMovement.clientState.Buying;
    }

    public void AskIfFreeSpot()
    {

    }

    void SetQueueManager(QueueManager _qm)
    {
        qm = _qm:
    }


    //TODO MAKE CLIENT MOVEFORWARD IN QUEUE, FREE LAST SPOT ON QUEUE,
}
