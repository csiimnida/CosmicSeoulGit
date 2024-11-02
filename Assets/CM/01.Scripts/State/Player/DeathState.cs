using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : PlayerState
{
    public DeathState(Player player) : base(player)
    {

    }

    protected override void EnterState(){
        if(_player.GroundChecker.IsGround)
            _player.RbCompo.bodyType = RigidbodyType2D.Static;
        else
            _player.RbCompo.velocity = Vector2.zero;
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _player.ColCompo.enabled = false;
        _player.OnDeathEventInvoke();
    }

    public override void UpdateState(){
        if(_player.GroundChecker.IsGround)
            _player.RbCompo.bodyType = RigidbodyType2D.Static;
    }

    protected override void ExtiState(){
        _player.RbCompo.bodyType = RigidbodyType2D.Dynamic;
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
        _player.ColCompo.enabled = true;
    }
}
