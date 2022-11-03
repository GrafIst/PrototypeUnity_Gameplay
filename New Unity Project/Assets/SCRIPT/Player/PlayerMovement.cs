using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed, dashStrenght;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();   
    }

    void HandleInput()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (Vector3.right * speed * Time.deltaTime);
            float rotation = Vector3.Angle(transform.forward, Vector3.right);
            transform.Rotate(0, rotation, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.forward * speed * Time.deltaTime);
            float rotation = Vector3.Angle(transform.forward, Vector3.forward);
            transform.Rotate(0, rotation, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.left * speed * Time.deltaTime);
            float rotation = Vector3.Angle(transform.forward, Vector3.left);
            transform.Rotate(0, rotation, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.back * speed * Time.deltaTime);
            float rotation = Vector3.Angle(transform.forward, Vector3.back);
            transform.Rotate(0, rotation, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 1).ToList();
            Collider interactable = hitColliders.Find(c => c.CompareTag("Interractable"));
            if (interactable){
                interactable.GetComponent<IInterract>().Interract();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(transform.forward * dashStrenght, ForceMode.Impulse);
        }

    }

}
