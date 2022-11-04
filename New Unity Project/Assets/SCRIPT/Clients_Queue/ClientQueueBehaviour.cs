using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientQueueBehaviour : MonoBehaviour
{
    [SerializeField] ClientsMovement cm;


    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponentInChildren<ClientsMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveTowardsSpot()
    {
        cm.activeState = ClientsMovement.clientState.MoveTowards;
    }
}
