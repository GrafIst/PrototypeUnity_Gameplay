using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientsMovement : MonoBehaviour
{

    [SerializeField] float clientSpeed;

    public enum clientState { Walk, MoveTowards, Buying}

    public clientState activeState = clientState.Walk;

    // Start is called before the first frame update
    void Start()
    {
        clientSpeed = Random.Range(3, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (activeState)
        {
            case clientState.Walk:
                Debug.Log("Client is walking");
                transform.position += transform.right * clientSpeed * Time.deltaTime;
                break;

            case clientState.MoveTowards:
                Debug.Log("Walking towards queue spot");
                break;

            case clientState.Buying:
                Debug.Log("Busy buying and waiting");
                break;
        }
        
    }
}
