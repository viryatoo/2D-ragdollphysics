using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class DesktopInput : ITickable, ICustomInput
{
    public Vector2 Direction => direction;
    public Vector2 AirDirection => airDirection;
    public event Action JumpPressed;
    public event Action JumpReleased;
    public event Action AirFlipPressed;
    public event Action AirFlipReleased;
    public event Action MouseClicked;

    [Inject] private readonly PlayerInputSettings settings;

    private Vector2 direction;
    private Vector2 airDirection;
    private float sensitivity = 0;
    private float airSensitivity;
    private const KeyCode KEY_JUMP = KeyCode.Space;

    public void Tick()
    {
        direction.x = Math.Sign(Input.GetAxis("Horizontal"));
        airDirection.x = Mathf.MoveTowards(airDirection.x, 0, Time.deltaTime * settings.AirFriction);
        if (direction.x != 0)
        {
            sensitivity += Time.deltaTime * direction.x * settings.Acceleration;
        }
        else
        {
            sensitivity = Mathf.MoveTowards(sensitivity, 0, Time.deltaTime * settings.AccelerationStop);
        }
        sensitivity = Mathf.Clamp(sensitivity, -1, 1);
        direction.x = sensitivity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            airDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            airDirection.x = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            AirFlipPressed?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            AirFlipReleased?.Invoke();
        }
        if (Input.GetKeyDown(KEY_JUMP))
        {
            JumpPressed?.Invoke();
        }
        if (Input.GetKeyUp(KEY_JUMP))
        {
            JumpReleased?.Invoke();
        }
        if(Input.GetMouseButtonDown(0))
        {
            MouseClicked?.Invoke();
        }
    }
}