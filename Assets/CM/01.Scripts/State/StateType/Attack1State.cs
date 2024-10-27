using UnityEngine;

public class Attack1State : PlayerState
{
    public Attack1State(Player player) : base(player)
    {

    }
    protected override void EnterState()
    {
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.AnimCompo.PlayAnimaiton(AnimationType.Attack1);
        _player.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState()
    {
        if (_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.7f)
            _player.TransitionState(PlayerStateType.Idle);
    }

    protected override void HandleAttackPressed()
    {
        if (_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            _player.TransitionState(PlayerStateType.Attack2);
    }

    protected override void HandleRollPressed()
    {
        _player.TransitionState(PlayerStateType.Roll);
    }

    protected override void ExtiState()
    {
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
    }
}
