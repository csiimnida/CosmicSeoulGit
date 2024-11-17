using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : PlayerState{
    
    private float curGravityScale;
    public RollState(Player player) : base(player){
    }

    protected override void EnterState(){
        _player.AnimCompo.PlayAnimaiton(AnimationType.Roll);
        if(_player.InputCompo.InputVector.x != 0)
            _player.transform.localScale = new Vector3(_player.InputCompo.InputVector.x,_player.transform.localScale.y,_player.transform.localScale.z);
        _player.RbCompo.AddForce(
            new Vector2(_player.transform.localScale.x * _player.PlayerData.RollPower, 0),
            ForceMode2D.Impulse);
    }

    public override void UpdateState(){
        if (_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") &&
            _player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _player.TransitionState(PlayerStateType.Idle);
        }
    }

    protected override void ExtiState(){
        _player.PlayerData.CanRool = false;
        _player.PlayerData.CurrentRoolTime = 0;
    }
}