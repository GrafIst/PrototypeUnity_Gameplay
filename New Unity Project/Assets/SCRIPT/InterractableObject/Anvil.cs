using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour, IInterract
{
    //SphereCollider sc;

    private void Awake()
    {
        //sc = GetComponent<SphereCollider>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interract()
    {
        Debug.Log("Anvil is interracted");
    }


}
