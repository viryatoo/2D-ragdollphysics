using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapPlatform : MonoBehaviour, I2DJointConnectable
{
    [SerializeField] private SliderJoint2D sliderJoint2D;
    [SerializeField] private Rigidbody2D rigidbody;

    public Rigidbody2D GetRigidBodyToConnectToJoint()
    {
        rigidbody.isKinematic = false;
        sliderJoint2D.enabled = true;
        return rigidbody;
    }

    public void OnJointUnconnected()
    {

    }
}
