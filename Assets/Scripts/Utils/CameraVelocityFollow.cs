using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraVelocityFollow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D followBody;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;

    [SerializeField] private float minOrthSize;
    [SerializeField] private float maxOrthSize;
    [SerializeField] private float forceEffectValue;

    private void Update()
    {
        var speed = followBody.velocity.magnitude;
        var result = speed * forceEffectValue;
        result = Mathf.Clamp(result, minOrthSize, maxOrthSize);
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, result, Time.deltaTime);
    }
}
