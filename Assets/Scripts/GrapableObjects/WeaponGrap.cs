using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrap : MonoBehaviour, I2DJointConnectable
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private int ingoreLayerIndex;
    [SerializeField] private GameObject[] weaponParts;

    public Rigidbody2D GetRigidBodyToConnectToJoint()
    {
        return rigidbody;
    }

    public void OnJointUnconnected()
    {
        foreach (var weaponPart in weaponParts)
        {
            weaponPart.layer = ingoreLayerIndex;
        }
    }
}
