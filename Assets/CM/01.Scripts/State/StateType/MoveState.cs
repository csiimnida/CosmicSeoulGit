using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(Player player) : base(player){
    }

    protected override void EnterState()
    {
        _player.AnimCompo.PlayAnimaiton(AnimationType.Move);
        _player.RotCompo.FaceDirection(_player.InputCompo.InputVector);
    }

    public override void FixedUpdateState()
    {
        _player.RbCompo.velocity = new Vector2(_player.InputCompo.InputVector.x * _player.PlayerData.MoveSpeed, _player.RbCompo.velocity.y);
    }

    public override void UpdateState()
    {
        if (_player.InputCompo.InputVector.x == 0)
            _player.TransitionState(PlayerStateType.Idle);
        if(_player.GroundChecker.IsGround == false)
            _player.TransitionState(PlayerStateType.Fall);
    }

    protected override void HandleJumpPressed()
    {
        _player.TransitionState(PlayerStateType.Jump);
    }
    protected override void HandleRollPressed()
    {
        _player.TransitionState(PlayerStateType.Roll);
    }
    protected override void HandleBlockPressed()
    {
        _player.TransitionState(PlayerStateType.Block);
    }
    protected override void HandleAttackPressed()
    {
        _player.TransitionState(PlayerStateType.Attack1);
    }

}
