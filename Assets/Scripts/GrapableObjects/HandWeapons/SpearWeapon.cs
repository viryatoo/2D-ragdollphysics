using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour, IGameSubject
{
    [SerializeField] private FollowJoint2DNonPhysics followJoint;
    [SerializeField] private Vector3 offsetConnectedPosition;
    [SerializeField] private float offsetConnectedRotation;
    [SerializeField] private PolygonCollider2D hitBoxColider;

    private FixedJoint2D fixedJoint;
    private PlayerHand playerHand;
    private bool activated = false;

    public bool PerformAction()
    {
        return true;
    }

    public void RemoveSubject()
    {
        followJoint.RemoveTarget();
        playerHand.DisableFollowHand();
        RemoveJoint2D();
        hitBoxColider.enabled = false;
    }

    public void TakeSubject(PlayerHand hand)
    {
        if (activated == false)
        {
            followJoint.SetTarget(hand.TransformForConnectWeapon);
            playerHand = hand;
            BodyConnect();
            hand.EnableFollowHand();
            hitBoxColider.enabled = true;
            activated = true;

        }
    }

    private void BodyConnect()
    {
        transform.localPosition = offsetConnectedPosition;
        transform.localRotation = Quaternion.Euler(0, 0, offsetConnectedRotation);
        Physics2D.SyncTransforms();
        CreateConnectJoint2D();
    }

    private void CreateConnectJoint2D()
    {
        fixedJoint = gameObject.AddComponent<FixedJoint2D>();
        fixedJoint.connectedBody = playerHand.RigidBodyForConnectWeapon;
    }

    private void RemoveJoint2D()
    {
        Destroy(fixedJoint);
    }
}
