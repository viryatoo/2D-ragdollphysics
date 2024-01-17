using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamWeapon : MonoBehaviour, IGameSubject
{
    [SerializeField] private FollowJoint2DNonPhysics followJoint;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private int hooksCount;
    [SerializeField] private Vector3 offsetConnectedPosition;
    [SerializeField] private float offsetConnectedRotation;

    private FixedJoint2D fixedJoint;
    private PlayerHand playerHand;

    public bool PerformAction()
    {
         return true;
    }

    public void RemoveSubject()
    {
        followJoint.RemoveTarget();
        playerHand.DisableFollowHand();
        RemoveJoint2D();
    }

    public void TakeSubject(PlayerHand hand)
    {
        if (hooksCount > 0)
        {
            followJoint.SetTarget(hand.TransformForConnectWeapon);
            hand.EnableFollowHand();
            playerHand = hand;
            BodyConnect();
        }
    }

    private void BodyConnect()
    {
        transform.localPosition = offsetConnectedPosition;
        transform.localRotation = Quaternion.Euler(0,0, offsetConnectedRotation);
        Physics2D.SyncTransforms();
        CreateConnectJoint2D();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDestroybleObject destroybleObject))
        {
            destroybleObject.DestroySubject(transform, 0);
        }
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
