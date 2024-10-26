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

        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
    }

    public override void UpdateState()
    {
        if (_player.RbCompo.velocity.y < 0)
        {
            _player.TransitionState(PlayerStateType.Fall);
        }
    }

    protected override void ExtiState()
    {
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
    }
}
