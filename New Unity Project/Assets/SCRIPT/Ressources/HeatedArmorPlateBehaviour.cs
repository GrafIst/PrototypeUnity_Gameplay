using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatedArmorPlateBehaviour : MonoBehaviour, IItem, IHammer
{
    public GameObject hammeredObject;

    public GameObject Hammered()
    {
        GameObject copyObject = hammeredObject;
        return copyObject;
    }

    
}
