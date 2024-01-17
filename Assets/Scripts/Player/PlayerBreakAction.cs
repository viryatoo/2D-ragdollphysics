using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreakAction : MonoBehaviour, IRiderBreakAction
{
    public event Action PlayerBroken;
    
    [SerializeField] private FixedJoint2D leftThiefJoint;
    [SerializeField] private FixedJoint2D rightThiefJoint;
    [SerializeField] private SliderJoint2D sliderJoint;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MonoWheelMovement monoWheelMovement;
    [SerializeField] private MonoWheelStabilizer wheelStabilizer;
    [SerializeField] private Rigidbody2D wheelBody;
    [SerializeField] private PlayerHand hand;

    public void RiderBroke()
    {
        leftThiefJoint.enabled = false;
        rightThiefJoint.enabled = false;
        playerMovement.enabled = false;
        monoWheelMovement.enabled = false;
        wheelStabilizer.enabled = false;
        sliderJoint.enabled = false;
        wheelBody.freezeRotation = false;
        hand.DisableFollowHand();
        PlayerBroken?.Invoke();
        Destroy(this);
    }
}
