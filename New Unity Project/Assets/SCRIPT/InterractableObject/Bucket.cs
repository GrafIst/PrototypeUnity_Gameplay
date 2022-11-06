using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour, IInterract
{
    public bool isWater;
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
        if (isWater)
        {
            Debug.Log("Water bucket is interracted");
        }
        else
        {
            //is lava
            Debug.Log("Lava bucket is interracted");
        }
        
    }
}
