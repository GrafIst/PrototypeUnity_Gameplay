using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBladeBehaviour : MonoBehaviour, IItem, IHeat
{
    public GameObject heatedObject;

    public GameObject Heat()
    {
        return heatedObject;
    }


}
