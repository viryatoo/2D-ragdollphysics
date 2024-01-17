using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowJoint2DNonPhysics : MonoBehaviour
{
    private Transform previousParrent;

    private void Start()
    {
        previousParrent = transform.parent;
    }

    public void SetTarget(Transform target)
    {
        transform.position = target.position;
        transform.parent = target;
    }
        
    public void RemoveTarget()
    {
        transform.parent = previousParrent;
    }
}
