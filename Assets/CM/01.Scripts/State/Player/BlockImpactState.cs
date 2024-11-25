using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockImpactState : PlayerState
{
    public BlockImpactState(Player player) : base(player)
    {

    }

    protected override void EnterState(){
        _player.InputCompo.OnMoveEvent -= _player.RotCompo.FaceDirection;
        _player.AnimCompo.PlayAnimaiton(AnimationType.BlockImpact);
        _player.RbCompo.AddForce(new Vector2(-_player.transform.localScale.x * _player.PlayerData.AttackForwardDistance, _player.RbCompo.velocity.y), ForceMode2D.Impulse);
    }

    public override void UpdateState(){
        if(_player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("BlockImpact") && _player.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            _player.TransitionState(PlayerStateType.Idle);
    }

    protected override void ExtiState(){
        _player.InputCompo.OnMoveEvent += _player.RotCompo.FaceDirection;
    }
}
