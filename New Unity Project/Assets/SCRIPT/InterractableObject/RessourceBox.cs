using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceBox : MonoBehaviour, IInterract
{
    public enum item { Leather, Ingot }

    public item itemProvided;
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
        Debug.Log("Ressourcebox is interracted");
    }
}
