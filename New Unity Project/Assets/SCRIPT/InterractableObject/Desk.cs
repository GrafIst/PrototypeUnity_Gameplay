using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour, IInterract
{
    [SerializeField] QueueManager qm;

    public void Interract()
    {
        if(qm.clientOnSpots.Count > 0) //making sure there is a client
        {
            Debug.Log("I interract with client");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
