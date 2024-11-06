using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(Player player) : base(player)
    {

    }

    protected override void EnterState()
    {
        _player.AnimCompo.PlayAnimaiton(AnimationType.Idle);
        _player.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState()
    {
        if (Mathf.Abs(_player.RbCompo.velocity.x) > 0  || Mathf.Abs(_player.InputCompo.InputVector.x) > 0)
            _player.TransitionState(PlayerStateType.Move);
        if (_player.GroundChecker.IsGround == false)
            _player.TransitionState(PlayerStateType.Fall);
    }

    protected override void HandleMovement(Vector2 vector)
    {
        _player.TransitionState(PlayerStateType.Move);
    }

    protected override void HandleJumpPressed()
    {
        _player.TransitionState(PlayerStateType.Jump);
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

    protected override void HandleAttackPressed()
    {
        _player.TransitionState(PlayerStateType.Attack1);
    }

    protected override void HandleSkill1Pressed(){
        if(_player.PlayerData.CanSkill1)
            _player.TransitionState(PlayerStateType.Skill1);
    }

    protected override void HandleSkill2Pressed(){
        if(_player.PlayerData.CanSkill2)
            _player.TransitionState(PlayerStateType.Skill2);
    }
}
