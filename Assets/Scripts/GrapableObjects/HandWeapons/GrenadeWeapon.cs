using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class GrenadeWeapon : MonoBehaviour, IGameSubject
{
    [SerializeField] private FollowJoint2DNonPhysics followJoint;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float dropForce;
    [SerializeField] private float explosiveForce;
    [SerializeField] private float explosiveRadius;
    [SerializeField] private ParticleSystem explosiveEffect;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Camera mainCamera;
    private PlayerHand playerHand;
    private bool isActivated;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public bool PerformAction()
    {
        body.isKinematic = false;
        body.freezeRotation = false;
        var direction = (mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        body.AddForce(direction * dropForce);
        playerHand.RigidBodyForConnectWeapon.AddForce(direction * dropForce);
        isActivated = true;
        return true;
    }

    public void RemoveSubject()
    {
        followJoint.RemoveTarget();
    }

    public void TakeSubject(PlayerHand hand)
    {
        followJoint.SetTarget(hand.TransformForConnectWeapon);
        body.isKinematic = true;
        playerHand = hand;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActivated && collision.gameObject.CompareTag("Ground"))
        {
            ActivateExplosion();
        }
        if (isActivated && collision.gameObject.TryGetComponent(out IDestroybleObject destroybleObject))
        {
            destroybleObject.DestroySubject(transform, explosiveForce);
            ActivateExplosion();
        }
    }

    private void ActivateExplosion()
    {
        spriteRenderer.enabled = false;
        explosiveEffect.Play();
        if ((transform.position - playerHand.PlayerBody.transform.position).sqrMagnitude < explosiveRadius)
        {
            var direction = (transform.position - playerHand.PlayerBody.transform.position).normalized * -1;
            playerHand.PlayerBody.ApplayForce(direction * explosiveForce * 30);
        }
        isActivated = false;
        Destroy(gameObject,3f);
    }
}
