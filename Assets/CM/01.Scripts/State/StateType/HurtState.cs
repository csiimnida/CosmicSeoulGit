using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : PlayerState
{
    public HurtState(Player player) : base(player)
    {

    }

    protected override void EnterState(){
        _player.AnimCompo.PlayAnimaiton(AnimationType.Hurt);
        _player.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState(){
        if(_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && _player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            _player.TransitionState(PlayerStateType.Idle);
    }
}
