using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using static UnityEngine.GraphicsBuffer;

public class MonoWheelStabilizer : MonoBehaviour
{
    public bool OnGround { get; private set; }
    public Vector2 NormalGround => normal;

    [Inject] private readonly IRiderBreakAction playerBreakAction;

    [SerializeField] private Transform leftCheckRay;
    [SerializeField] private Transform rightCheckRay;
    [SerializeField] private Transform leftDropCheckRay;
    [SerializeField] private Transform rightDropCheckRay;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float raycastDistance;

    private RaycastHit2D leftRayResult;
    private RaycastHit2D rightRayResult;
    private Vector3 normal = Vector2.zero;
    private Vector2 direction;
    private int layerMask = 1 << 0;

    private void FixedUpdate()
    {
        if (PlayerOnGround())
        {
            if (Vector2.SignedAngle(Vector2.up, body.transform.up) > 30)
            {
                OnGround = false;
                body.freezeRotation = false;
            }
            else
            {
                body.freezeRotation = true;
                OnGround = true;
            }
            direction = (rightRayResult.point - leftRayResult.point).normalized;
            normal = new Vector2(direction.y, -direction.x) * -1;
        }
        else
        {
            OnGround = false;
            if (PlayerCrashed())
            {
                if (Vector2.SignedAngle(Vector2.up, body.transform.up) > 50)
                {
                    playerBreakAction.RiderBroke();
                }
            }
        }
    }

    private bool PlayerCrashed()
    {
        leftRayResult = Physics2D.Raycast(leftDropCheckRay.position, leftDropCheckRay.up, raycastDistance / 1.5f, layerMask);
        rightRayResult = Physics2D.Raycast(rightDropCheckRay.position, rightDropCheckRay.up, raycastDistance / 1.5f, layerMask);
        return leftRayResult || leftRayResult;
    }

    private bool PlayerOnGround()
    {
        leftRayResult = Physics2D.Raycast(leftCheckRay.position, body.transform.up * -1, raycastDistance, layerMask);
        rightRayResult = Physics2D.Raycast(rightCheckRay.position, body.transform.up * -1, raycastDistance, layerMask);
        return leftRayResult && rightRayResult;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawLine(transform.position, transform.position + normal);
            Gizmos.color = Color.yellow;
            if (leftRayResult && rightRayResult)
            {
                Gizmos.DrawLine(rightRayResult.point, leftRayResult.point);
                Gizmos.DrawLine(leftCheckRay.position, leftCheckRay.position + body.transform.up * -1 * raycastDistance);
                Gizmos.DrawLine(rightCheckRay.position, rightCheckRay.position + body.transform.up * -1 * raycastDistance);
                Gizmos.DrawLine(leftDropCheckRay.position, leftDropCheckRay.position + leftDropCheckRay.up * raycastDistance / 1.5f);
                Gizmos.DrawLine(rightDropCheckRay.position, rightDropCheckRay.position + rightDropCheckRay.up * raycastDistance / 1.5f);
            }
        }
    }
}