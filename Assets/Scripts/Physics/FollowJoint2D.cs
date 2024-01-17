using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetJoint2D))]
public class FollowJoint2D : MonoBehaviour
{
    [SerializeField] private HingeJoint2D jointForConnect;
    [SerializeField] private TargetJoint2D targetJoint;

    private Transform target;

    private void FixedUpdate()
    {
        if (jointForConnect.connectedBody != null)
        {
            var isGrap = (jointForConnect.connectedBody.transform.position - transform.position).magnitude < 0.3f;
            if (isGrap)
            {
                targetJoint.enabled = false;
                jointForConnect.enabled = true;
            }
            else
            {
                targetJoint.target = jointForConnect.connectedBody.transform.position;
            }
        }
        if(target != null )
        {
            targetJoint.target = target.position;
        }
    }

    public void SetConnectedBody(Rigidbody2D connectedBody)
    {
        jointForConnect.connectedBody = connectedBody;
        targetJoint.enabled = true;
    }

    public void RemoveConnectedBody()
    {
        targetJoint.enabled = false;
        jointForConnect.enabled = false;
        jointForConnect.connectedBody = null;
    }
}
