using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : PlayerState
{
    public DeathState(Player player) : base(player)
    {

    }

    protected override void EnterState(){
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.TransitionState(PlayerStateType.Death);
        _player.RbCompo.velocity = new Vector2(0,_player.RbCompo.velocity.y);
    }

    protected override void ExtiState(){
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
    }
}
