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
        if (Mathf.Abs(_player.InputCompo.InputVector.x) > 0)
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
        _player.TransitionState(PlayerStateType.Roll);
    }

    protected override void HandleBlockPressed()
    {
        _player.TransitionState(PlayerStateType.Block);
    }
}
