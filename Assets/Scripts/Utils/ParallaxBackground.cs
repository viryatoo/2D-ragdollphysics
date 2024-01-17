using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform followingTarget;
    [SerializeField, Range(0f, 1f)] private float parallaxStrenght = 0.1f;
    [SerializeField] private bool disableVerticalParalax;

    private Vector3 targetPreviousPosition;

    void Start()
    {
        if(!followingTarget)
        {
            followingTarget = Camera.main.transform;
        }
        targetPreviousPosition = followingTarget.position;
    }

    void Update()
    {
        var delta =  followingTarget.position - targetPreviousPosition;
        if(disableVerticalParalax)
        {
            delta.y = 0f;
        }
        targetPreviousPosition = followingTarget.position;
        transform.position += delta * parallaxStrenght;
    }
}
