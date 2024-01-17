using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomInput
{
    public Vector2 Direction { get;}
    public Vector2 AirDirection { get; }
    public event Action JumpPressed;
    public event Action JumpReleased;
    public event Action AirFlipPressed;
    public event Action AirFlipReleased;
    public event Action MouseClicked;
}

