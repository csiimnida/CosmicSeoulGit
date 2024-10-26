using UnityEngine;

public class BlockState : PlayerState
{
    public BlockState(Player player) : base(player)
    {

    }

    protected override void EnterState()
    {
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.AnimCompo.PlayAnimaiton(AnimationType.Block);
        _player.RbCompo.velocity = Vector2.zero;
        _player.PlayerData.currentTime = 0;
    }

    public override void UpdateState()
    {
        _player.PlayerData.currentTime += Time.deltaTime;
        if (_player.PlayerData.currentTime >= _player.PlayerData.BlockingTime)
        {
            _player.TransitionState(PlayerStateType.Idle);
        }
    }

    protected override void ExtiState()
    {
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
    }
}
