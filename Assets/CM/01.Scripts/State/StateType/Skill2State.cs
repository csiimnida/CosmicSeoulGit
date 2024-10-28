using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2State : PlayerState
{
    public Skill2State(Player player) : base(player)
    {

    }
    protected override void EnterState(){
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.AnimCompo.PlayAnimaiton(AnimationType.Skill2);
        _player.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState(){
        if(_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            _player.TransitionState(PlayerStateType.Idle);
    }

    protected override void ExtiState(){
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
    }
}
