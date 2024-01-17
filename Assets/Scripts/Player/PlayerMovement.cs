using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce => jumpForce;

    [Inject] private readonly ICustomInput playerInput;
    [Inject] private readonly WheelSettings wheelSettings;

    [SerializeField] private float riderTranslationLimitY;
    [SerializeField] private Rigidbody2D riderBody;
    [SerializeField] private Rigidbody2D wheelBody;
    [SerializeField] private SliderJoint2D connectedJoint;
    [SerializeField] private MonoWheelStabilizer wheelStabilizer;
    [SerializeField] private float balanceForceInAir;
    [SerializeField] private PlayerGrap playerGrap;

    private JointTranslationLimits2D cashedLimits;
    private bool isJump;
    private bool isGroup;
    private float jumpForce;
    private JointTranslationLimits2D jumpLimits;

    private void Start()
    {
        cashedLimits = connectedJoint.limits;
        jumpLimits = new JointTranslationLimits2D
        {
            max = riderTranslationLimitY,
            min = cashedLimits.min
        };
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void FixedUpdate()
    {
        if (!wheelStabilizer.OnGround && playerInput.AirDirection.x != 0)
        {
            wheelBody.freezeRotation = false;
            riderBody.MoveRotation(riderBody.rotation +
                                   balanceForceInAir * Time.fixedDeltaTime * playerInput.AirDirection.x * -1);
        }
        else
        {
            if (playerGrap.IsGrap)
            {
                wheelBody.freezeRotation = false;
            }
            else
            {
                wheelBody.freezeRotation = true;
            }
        }
    }

    private IEnumerator Jump()
    {
        var currentJointLimit = cashedLimits;
        while (isJump)
        {
            currentJointLimit.min = cashedLimits.min;
            currentJointLimit.max = Mathf.MoveTowards(currentJointLimit.max, jumpLimits.max, Time.deltaTime);
            jumpForce = Mathf.MoveTowards(jumpForce, wheelSettings.MaxJumpForce,
                Time.deltaTime * wheelSettings.JumpTime);
            connectedJoint.limits = currentJointLimit;
            yield return null;
        }
        connectedJoint.limits = cashedLimits;
        if (wheelStabilizer.OnGround)
        {
            riderBody.AddForce(Vector2.up * (jumpForce * 1000));
        }
        jumpForce = 0;
    }

    private IEnumerator BodyGroup()
    {
        var currentJointLimit = cashedLimits;
        while (isGroup)
        {
            currentJointLimit.min = cashedLimits.min;
            currentJointLimit.max = Mathf.MoveTowards(currentJointLimit.max, jumpLimits.max, Time.deltaTime);
            connectedJoint.limits = currentJointLimit;
            yield return null;
        }
        connectedJoint.limits = cashedLimits;
    }

    private void Subscribe()
    {
        playerInput.JumpPressed += OnJumpPressed;
        playerInput.JumpReleased += OnJumpReleased;
        playerInput.AirFlipPressed += OnAirFlipPressed;
        playerInput.AirFlipReleased += OnAirFlipReleased;
    }

    private void Unsubscribe()
    {
        playerInput.JumpPressed -= OnJumpPressed;
        playerInput.JumpReleased -= OnJumpReleased;
        playerInput.AirFlipPressed -= OnAirFlipPressed;
        playerInput.AirFlipReleased -= OnAirFlipReleased;
    }

    private void OnJumpPressed()
    {
        if (wheelStabilizer.OnGround)
        {
            isJump = true;
            StartCoroutine(Jump());
        }
    }

    private void OnJumpReleased()
    {
        isJump = false;
    }

    private void OnAirFlipPressed()
    {
        isGroup = true;
        StartCoroutine(BodyGroup());
    }

    private void OnAirFlipReleased()
    {
        isGroup = false;
    }
}