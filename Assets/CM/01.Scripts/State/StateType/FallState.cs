using UnityEngine;

public class FallState : PlayerState
{
    public FallState(Player player) : base(player)
    {

    }

    protected override void EnterState()
    {
        _player.AnimCompo.PlayAnimaiton(AnimationType.Fall);
    }

    public override void UpdateState()
    {
        if (_player.GroundChecker.IsGround)
        {
            _player.TransitionState(PlayerStateType.Idle);
        }
    }

    protected override void HandleMovement(Vector2 vector){
        _player.RbCompo.velocity = new Vector2(_player.InputCompo.InputVector.x * _player.PlayerData.MoveSpeed, _player.RbCompo.velocity.y);
    }
}
