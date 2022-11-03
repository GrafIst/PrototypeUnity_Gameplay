using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGrabbr : MonoBehaviour
{
    [SerializeField] GameObject grabbedObject;
    [SerializeField] float throwStrenght;
    [SerializeField] Transform playerHandSocket;

    Transform grabbedItemSocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && grabbedObject != null)
        {
            ThrowItem();
        }

        if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
        {
            
            //Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);
            List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 1).ToList();
            Collider interactable = hitColliders.Find(c => c.CompareTag("Throwable"));
            if (interactable)
            {
                grabbedItemSocket = interactable.GetComponent<IThrowable>().GetGrabSocket();
                grabbedObject = interactable.GetComponent<IThrowable>().Grab();
                GrabItem();
            }
            //if (hitColliders[0].CompareTag("Throwable"))
            //{
                
            //    //hitColliders[0].transform.parent = playerHandSocket.transform;
            //    grabbedItemSocket = hitColliders[0].GetComponent<IThrowable>().GetGrabSocket();
            //    grabbedObject = hitColliders[0].GetComponent<IThrowable>().Grab();
            //    GrabItem();
            //}
        }

        
    }

    void GrabItem()
    {
        Rigidbody grabbedRb = grabbedObject.GetComponent<Rigidbody>();
        grabbedRb.detectCollisions = false;
        grabbedRb.useGravity = false;
        grabbedObject.transform.parent = playerHandSocket.transform;
        grabbedObject.transform.position = playerHandSocket.position;
    }

    void ThrowItem()
    {
        //first unparent, then addforce

        //playerHandSocket.DetachChildren();
        Rigidbody grabbedRb = grabbedObject.GetComponent<Rigidbody>();

        grabbedRb.detectCollisions = true;
        grabbedRb.useGravity = true;
        grabbedObject.GetComponent<MakeThrowable>().SetFree();

        grabbedRb.AddForce(transform.forward * throwStrenght, ForceMode.Impulse);

        Invoke("DelayUnref", .1f);
        
        //grabbedObject = null;
    }

    void DelayUnref()
    {
        grabbedObject = null;
    }
}