using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2State : PlayerState
{
    public Attack2State(Player player) : base(player)
    {

    }

    protected override void EnterState()
    {
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.AnimCompo.PlayAnimaiton(AnimationType.Attack2);
        _player.RbCompo.velocity = Vector2.zero;
        _player.RbCompo.AddForce(new Vector2(_player.PlayerData.AttackForwardDistance, 0), ForceMode2D.Impulse);
    }

    public override void UpdateState()
    {
        if (_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && _player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            _player.TransitionState(PlayerStateType.Idle);
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
