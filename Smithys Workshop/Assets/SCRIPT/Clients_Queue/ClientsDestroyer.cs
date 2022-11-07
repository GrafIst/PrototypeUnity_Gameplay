using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientsDestroyer : MonoBehaviour
{

    [SerializeField] QueueManager qm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            //qm.RemoveClient(other.transform.root.gameObject);
            Destroy(other.transform.root.gameObject, 0.1f);
        }
    }
}
