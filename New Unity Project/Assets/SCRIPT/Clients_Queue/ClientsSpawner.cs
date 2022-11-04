using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientsSpawner : MonoBehaviour
{

    [SerializeField] float spawnerRate, maxSpawnerRate = 10.0f;
    [SerializeField] GameObject client;
    [SerializeField] Transform spawnerSocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnerRate -= Time.deltaTime;

        if (spawnerRate <= 0)
        {
            SpawnClient();
            spawnerRate = maxSpawnerRate;
        }
    }

    void SpawnClient()
    {
        Instantiate(client, spawnerSocket.position, Quaternion.identity);
    }
}
