using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;

    public Collider currentCollider;
    

    bool interractKeyPressed = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInput();   
    }

    void HandleInput()
    {
        interractKeyPressed = false;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            if(currentCollider)
                currentCollider.GetComponent<IInterract>().Interract();
        }

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Interractable"))
    //    {
    //        other.GetComponent<IInterract>().Interract();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interractable"))
        {
            currentCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interractable"))
        {
            currentCollider = null;
        }
    }
}
