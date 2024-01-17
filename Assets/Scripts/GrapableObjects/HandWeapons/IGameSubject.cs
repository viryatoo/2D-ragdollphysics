using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IGameSubject
{
    public void TakeSubject(PlayerHand playerHand);
    public void RemoveSubject();
    public bool PerformAction();
}

