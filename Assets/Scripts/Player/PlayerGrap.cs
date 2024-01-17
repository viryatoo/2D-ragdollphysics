using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerGrap : MonoBehaviour
{
    public bool IsGrap { get; private set; }

    [Inject] private readonly ICustomInput input;

    [SerializeField] FollowJoint2D followJointLeft;
    [SerializeField] FollowJoint2D followJointRight;
    [SerializeField] private PlayerSubjectHandler hand;

    private I2DJointConnectable connectableObject;

    private void OnEnable()
    {
        input.MouseClicked += OnMouseClicked;
    }

    private void OnDisable()
    {
        input.MouseClicked -= OnMouseClicked;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<I2DJointConnectable>(out var obj) && hand.Empty)
        {
            var grapBody = obj.GetRigidBodyToConnectToJoint();
            followJointLeft.SetConnectedBody(grapBody);
            followJointRight.SetConnectedBody(grapBody);
            IsGrap = true;
            connectableObject = obj;
        }
    }

    private void OnMouseClicked()
    {
        followJointLeft.RemoveConnectedBody();
        followJointRight.RemoveConnectedBody();
        connectableObject?.OnJointUnconnected();
        IsGrap = false;
    }
}
