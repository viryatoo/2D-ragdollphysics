using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGrap : MonoBehaviour, I2DJointConnectable
{
    [SerializeField] private Rigidbody2D rigidBody;

    public Rigidbody2D GetRigidBodyToConnectToJoint()
    {
        return rigidBody;
    }

    public void OnJointUnconnected()
    {

    }
}
