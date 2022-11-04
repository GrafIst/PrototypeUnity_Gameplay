using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{

    [SerializeField] List<GameObject> queueSpots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddClientToQueue(GameObject go)
    {
        queueSpots.Add(go);
    }

    void RemoveClient()
    {
        queueSpots.RemoveAt(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if client walk in and a spot is free.
        if (other.CompareTag("Client"))
        {
            foreach (GameObject spot in queueSpots)
            {
                if (spot.CompareTag("FreeSpot"))
                {
                    //Found a free spot !

                    AddClientToQueue(other.transform.root.gameObject);
                    spot.tag = "Untagged";
                    spot.tag = "OccupiedSpot";
                    return;
                }
            }

            //else

        }

    }
}
