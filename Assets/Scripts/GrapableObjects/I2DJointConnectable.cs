using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I2DJointConnectable
{
    public Rigidbody2D GetRigidBodyToConnectToJoint();
    public void OnJointUnconnected();
}
