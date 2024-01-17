using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RiderJointBreakHandler : MonoBehaviour
{
    [Inject] private readonly IRiderBreakAction breakAction; 
    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        breakAction.RiderBroke();
    }
}
