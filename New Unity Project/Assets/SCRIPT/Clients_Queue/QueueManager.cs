using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QueueManager : MonoBehaviour
{

    [SerializeField] List<GameObject> queueSpots;
    public List<GameObject> clientOnSpots;
    public Transform exitSocket;

    void AddClientToQueue(GameObject go, Transform spot, int indexPos, Transform exitSpot)
    {
        clientOnSpots.Add(go);
        go.GetComponentInChildren<ClientsMovement>().SetupQueuePosition(spot, indexPos, exitSpot, this);
    }

    public void RemoveClient(GameObject go)
    {
        //Make all queueing png move forward one spot,
        clientOnSpots.Remove(go);
        UpdateQueue();
    }
    
    public void UpdateQueue()
    {
        for(int i = 0; i < queueSpots.Count; i++)
        {
            if(i < clientOnSpots.Count)
                clientOnSpots[i].GetComponentInChildren<ClientsMovement>().SetupQueuePosition(queueSpots[i].transform, i, exitSocket, this);

            if (i >= clientOnSpots.Count)
            {
                queueSpots[i].tag = "Untagged";
                queueSpots[i].tag = "FreeSpot";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if client walk in and a spot is free.
        if (other.CompareTag("Client"))
        {
            //Debug.Log("im detecting");
            foreach (GameObject spot in queueSpots)
            {
                if (spot.CompareTag("FreeSpot"))
                {
                    //Found a free spot !
                    AddClientToQueue(other.transform.root.gameObject, spot.transform, queueSpots.IndexOf(spot), exitSocket);
                    spot.tag = "Untagged";
                    spot.tag = "OccupiedSpot";

                    return;
                }
            }
            //else

        }

    }
}
