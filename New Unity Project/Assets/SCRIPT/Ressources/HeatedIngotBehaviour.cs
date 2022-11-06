using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatedIngotBehaviour : MonoBehaviour, IItem, IHammer, IWorkbench
{
    public GameObject hammeredObject;
    public GameObject workbenchObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Hammered()
    {
        return hammeredObject;
    }

    public GameObject WorkBenched()
    {
        return workbenchObject;
    }
}
