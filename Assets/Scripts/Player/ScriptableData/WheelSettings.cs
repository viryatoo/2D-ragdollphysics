using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "new wheel settings",menuName = "Game/Player/Wheel Settings",order = 51)]
public class WheelSettings : ScriptableObject
{
    public float MaxWheelForce => maxWheelForce;
    public float MaxFrequencyPerMinute => maxFrequencyPerMinute;
    public float Acceleration => acceleration;
    public PhysicsMaterial2D Material => material;
    public float MaxDeltaAngle => maxDeltaAngle;
    public float MaxJumpForce => maxJumpForce;
    public float JumpTime => jumpTime;

    [SerializeField] private float maxWheelForce;
    [SerializeField] private float maxFrequencyPerMinute;
    [SerializeField] private float acceleration;
    [SerializeField] private PhysicsMaterial2D material;
    [SerializeField] private float maxDeltaAngle;
    [SerializeField] private float maxJumpForce;
    [SerializeField] private float jumpTime;
}

