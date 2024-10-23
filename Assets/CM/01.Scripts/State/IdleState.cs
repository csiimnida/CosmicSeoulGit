using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player) : base(player)
    {

    }

    protected override void EnterState()
    {
        // �ִϸ��̼� ��ü
        _player.TransitionState(PlayerStateType.Move);
    }
}
