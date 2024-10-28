using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : PlayerState
{
    public RollState(Player player) : base(player)
    {

    }

    protected override void EnterState()
    {
        _player.AnimCompo.PlayAnimaiton(AnimationType.Roll);
        _player.RbCompo.AddForce(new Vector2(Mathf.Sign(_player.transform.localScale.x) * _player.PlayerData.RollPower, 0), ForceMode2D.Impulse);
        _player.ColCompo.enabled = false;
    }

    public override void UpdateState()
    {
        if (_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _player.TransitionState(PlayerStateType.Idle);
            _player.ColCompo.enabled = true;
        }
    }
}
