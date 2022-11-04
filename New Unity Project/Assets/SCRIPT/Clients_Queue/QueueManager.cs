using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{

    [SerializeField] List<GameObject> queueSpots;
    public List<GameObject> clientOnSpots;

    public Transform exitSocket;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void DetectDeadClientEmptyQueue()
    //{
        
    //}

    void AddClientToQueue(GameObject go, Transform spot)
    {
        clientOnSpots.Add(go);
        ClientQueueBehaviour currentClientBehaviour = go.GetComponentInChildren<ClientQueueBehaviour>();
        currentClientBehaviour.
        currentClientBehaviour.MoveTowardsSpot(spot);
        currentClientBehaviour.LeavingQueue(exitSocket);
    }

    public void RemoveClient(GameObject go)
    {
        //Make all queueing png move forward one spot,
        queueSpots[0].tag = "Untagged";
        queueSpots[0].tag = "FreeSpot";
        clientOnSpots.Remove(go);
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

                    AddClientToQueue(other.transform.root.gameObject, spot.transform);
                    spot.tag = "Untagged";
                    spot.tag = "OccupiedSpot";

                    if(queueSpots.IndexOf(spot) == 0)
                    {
                        //first client
                        other.transform.root.gameObject.GetComponentInChildren<ClientQueueBehaviour>().MakeFirst();
                    }
                    return;
                }
            }

            //else

        }

    }

    public List<GameObject> GetQueueSpot()
    {
        return queueSpots;
    }
}
