using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class MonoWheelMovement : MonoBehaviour
{
    [Inject] private readonly ICustomInput playerInput;
    [Inject] private readonly WheelSettings wheelSettings;

    [SerializeField] private MonoWheelStabilizer wheelStabilizer;
    [SerializeField] private Rigidbody2D wheelBody;
    [SerializeField] private Rigidbody2D wheel;
    [SerializeField] private float maxOffsetAngle;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        wheelBody.sharedMaterial = wheelSettings.Material;
    }

    private void FixedUpdate()
    {
        if (playerInput.Direction.x < -0.5 || playerInput.Direction.x > 0.5 && wheelStabilizer.OnGround)
        {
            wheelBody.AddTorque(playerInput.Direction.x * wheelSettings.Acceleration * -1);
        }
        if (wheelStabilizer.OnGround)
        {
            var currenAngle = maxOffsetAngle * playerInput.Direction.x * -1;
            var deltaAngle = Vector2.SignedAngle(Vector2.up, wheel.transform.up) * -1;
            var resultAngle = deltaAngle + currenAngle;
            wheel.rotation = Mathf.MoveTowards(wheel.rotation, wheel.rotation + resultAngle, Time.fixedDeltaTime * rotationSpeed);
        }
    }
}