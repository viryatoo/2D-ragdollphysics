using System;
using UnityEngine;
using Zenject;

//Пока просто как затычка. Позже можно будет сделать подвижных райдеров.
public class AIInput : ICustomInput
{
    public Vector2 Direction => direction;

    public Vector2 AirDirection => airDirection;

    public event Action JumpPressed;
    public event Action JumpReleased;
    public event Action AirFlipPressed;
    public event Action AirFlipReleased;
    public event Action MouseClicked;

    private Vector2 airDirection;
    private Vector2 direction;

}