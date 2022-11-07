using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFullBehaviour : MonoBehaviour, IItem, ISharpPolish
{
    public GameObject betterObject;
    public GameObject GetUpgrade()
    {
        return betterObject;
    }
}
