using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(Player player) : base(player)
    {
    
    }

    protected override void EnterState()
    {
        _player.AnimCompo.PlayAnimaiton(AnimationType.Idle);
    }

    public override void UpdateState(){
        if(Mathf.Abs(_player.InputCompo.InputVector.x) > 0)
            _player.TransitionState(PlayerStateType.Move);
    }
}
