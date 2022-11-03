using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeThrowable : MonoBehaviour, IThrowable
{
    [SerializeField] Transform socket;

    private void Awake()
    {
        gameObject.tag = "Throwable";
    }

    public GameObject Grab()
    {
        return gameObject;
    }

    public Transform GetGrabSocket()
    {
        return socket;
    }

    public void SetFree()
    {
        transform.SetParent( null);
    }
}
