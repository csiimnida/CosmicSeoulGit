using UnityEngine;

public class FallState : PlayerState
{
    public FallState(Player player) : base(player)
    {

    }

    protected override void EnterState()
    {
        _player.AnimCompo.PlayAnimaiton(AnimationType.Fall);
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
    }

    public override void UpdateState()
    {
        if (_player.GroundChecker.IsGround)
        {
            _player.TransitionState(PlayerStateType.Idle);
        }
    }

    protected override void ExtiState()
    {
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
    }
}
