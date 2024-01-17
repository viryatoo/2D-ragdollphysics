using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRiderBody : MonoBehaviour
{
    [SerializeField] private PlayerBreakAction breakAction;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float maxBreakForce;

    public void ApplayForce(Vector2 force)
    {
        if(force.sqrMagnitude>maxBreakForce)
        {
            rigidbody.AddForce(force);
            breakAction.RiderBroke();
        }
    }
}
