using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "new Input Settings", menuName = "Game/Player/Input Settings", order = 51)]
public class PlayerInputSettings : ScriptableObject
{
    public float Acceleration => acceleration;
    public float AccelerationStop => accelerationStop;
    public float AirFriction => airFriction;

    [SerializeField] private float acceleration;
    [SerializeField] private float accelerationStop;
    [SerializeField] private float airFriction;
}

