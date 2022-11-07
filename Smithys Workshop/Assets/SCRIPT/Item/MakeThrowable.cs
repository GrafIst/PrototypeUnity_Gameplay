using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeThrowable : MonoBehaviour, IThrowable
{
    
    private void Awake()
    {
        //gameObject.tag = "Throwable";
    }

    public GameObject Grab()
    {
        return gameObject;
    }


    public void SetFree()
    {
        transform.SetParent( null);
    }
}
