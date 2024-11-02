using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(Player player) : base(player)
    {
    }

    protected override void EnterState()
    {
        if (_player.GroundChecker.IsGround)
        {
            _player.AnimCompo.PlayAnimaiton(AnimationType.Jump);
            _player.RbCompo.AddForce(new Vector2(0, _player.PlayerData.JumpPower), ForceMode2D.Impulse);
        }
        else
            _player.TransitionState(PlayerStateType.Idle);
    }

    public override void UpdateState()
    {
        if (_player.RbCompo.velocity.y < 0)
        {
            _player.TransitionState(PlayerStateType.Fall);
        }
    }

    protected override void HandleMovement(Vector2 vector)
    {
        _player.RbCompo.velocity = new Vector2(_player.InputCompo.InputVector.x * _player.PlayerData.MoveSpeed, _player.RbCompo.velocity.y);
    }
}
