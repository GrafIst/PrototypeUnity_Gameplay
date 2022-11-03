using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThrowable
{
    GameObject Grab();
    Transform GetGrabSocket();
}
