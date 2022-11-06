using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBladeBehaviour : MonoBehaviour, IItem, IHeat
{
    public GameObject heatedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Heat()
    {
        return heatedObject;
    }
}
