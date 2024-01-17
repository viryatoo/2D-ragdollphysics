using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BrokeTrigger : MonoBehaviour
{
    [Inject] private readonly IRiderBreakAction breakAction;

    [SerializeField] private Rigidbody2D bodyHandler;
    [SerializeField] private float velocityForBroken;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.sqrMagnitude > velocityForBroken && other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Broked"))
        {

            if (breakAction != null)
            {
                breakAction.RiderBroke();
            }
        }
    }
}
