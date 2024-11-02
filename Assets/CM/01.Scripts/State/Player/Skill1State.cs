using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1State : PlayerState{
    public Skill1State(Player player) : base(player){
    }

    protected override void EnterState(){
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.AnimCompo.PlayAnimaiton(AnimationType.Skill1);
        _player.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState(){
        if (_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Skill1") &&
            _player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            _player.TransitionState(PlayerStateType.Idle);
    }

    protected override void ExtiState(){
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
        _player.PlayerData.CanSkill1 = false;
        _player.PlayerData.CurrentSkill1Time = 0f;
    }
    
    protected override void HandleRollPressed()
    {
        if(_player.PlayerData.CanRool)
            _player.TransitionState(PlayerStateType.Roll);
    }

    protected override void HandleBlockPressed()
    {
        if(_player.PlayerData.CanBlock)
            _player.TransitionState(PlayerStateType.Block);
    }
}