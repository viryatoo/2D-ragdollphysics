using UnityEngine;
using Zenject;

public class UIJumpForceModel: ITickable
{
    [Inject] private readonly PlayerMovement playerMovement;
    [Inject] private readonly WheelSettings settings;
    [Inject] private readonly UIJumpForceView jumpForceView;

    public void Tick()
    {
        jumpForceView.UpdateImage(playerMovement.JumpForce/settings.MaxJumpForce);
    }
}
