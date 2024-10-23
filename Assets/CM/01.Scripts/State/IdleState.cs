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
        // 애니메이션 교체
        _player.TransitionState(PlayerStateType.Move);
    }
}
