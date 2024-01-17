using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Transform TransformForConnectWeapon => bodyMHand.transform;
    public Rigidbody2D RigidBodyForConnectWeapon => bodyMHand;
    public PlayerRiderBody PlayerBody => playerBody;

    [SerializeField] private Rigidbody2D bodyHand;
    [SerializeField] private Rigidbody2D bodyFoream;
    [SerializeField] private Rigidbody2D bodyMHand;
    [SerializeField] private PlayerRiderBody playerBody;
    [SerializeField] private HingeJoint2D bodyHandJoint;
    [SerializeField] private HingeJoint2D bodyForeamJoint;
    [SerializeField] private HingeJoint2D bodyMHandJoint;


    [SerializeField] float fixedForeamRoation;
    [SerializeField] float fixedHandRoation;
    [SerializeField] float fixedMHandRoation;
    public void EnableFollowHand()
    {
        bodyHand.rotation = fixedHandRoation;
        bodyMHand.rotation = fixedMHandRoation;
        bodyFoream.rotation = fixedForeamRoation;

        bodyHand.freezeRotation = true;
        bodyMHand.freezeRotation = true;
        bodyFoream.freezeRotation = true;
    }
    public void DisableFollowHand()
    {
        bodyHand.freezeRotation = false;
        bodyMHand.freezeRotation = false;
        bodyFoream.freezeRotation = false;
    }
}
