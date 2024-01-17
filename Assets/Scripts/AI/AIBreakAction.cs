using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBreakAction : MonoBehaviour, IRiderBreakAction
{
    [SerializeField] private FixedJoint2D leftThiefJoint;
    [SerializeField] private FixedJoint2D rightThiefJoint;
    [SerializeField] private SliderJoint2D sliderJoint;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MonoWheelMovement monoWheelMovement;
    [SerializeField] private MonoWheelStabilizer wheelStabilizer;
    [SerializeField] private Rigidbody2D wheelBody;

    [SerializeField] GameObject[] riderPartObjects;
    [SerializeField] private int indexOfIgnoreLayer;

    public void RiderBroke()
    {
        leftThiefJoint.enabled = false;
        rightThiefJoint.enabled = false;
        playerMovement.enabled = false;
        monoWheelMovement.enabled = false;
        wheelStabilizer.enabled = false;
        sliderJoint.enabled = false;
        wheelBody.freezeRotation = false;
        DisableCollision();
        Destroy(this);
    }

    private void DisableCollision()
    {
        foreach (var part in riderPartObjects)
        {
            part.layer = indexOfIgnoreLayer;
        }
    }
}
