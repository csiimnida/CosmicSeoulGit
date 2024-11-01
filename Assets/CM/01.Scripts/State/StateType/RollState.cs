using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : PlayerState{
    
    private float curGravityScale;
    public RollState(Player player) : base(player){
    }

    protected override void EnterState(){
        _player.AnimCompo.PlayAnimaiton(AnimationType.Roll);
        _player.RbCompo.AddForce(
            new Vector2(_player.InputCompo.InputVector.x * _player.PlayerData.RollPower, 0),
            ForceMode2D.Impulse);
        curGravityScale = _player.RbCompo.gravityScale;
        _player.RbCompo.gravityScale = 0;
        
        _player.ColCompo.isTrigger = true;
    }

    public override void UpdateState(){
        if (_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") &&
            _player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _player.TransitionState(PlayerStateType.Idle);
            _player.ColCompo.isTrigger = false;
        }
    }

    protected override void ExtiState(){
        _player.PlayerData.CanRool = false;
        _player.PlayerData.CurrentRoolTime = 0;
        _player.RbCompo.gravityScale = curGravityScale;
    }
}