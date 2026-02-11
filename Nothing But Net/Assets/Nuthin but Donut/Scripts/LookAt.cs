using System;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.LookAt(target);
    }
    // todo - make an object look at another object
}
