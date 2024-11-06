using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodWorm_IdleState : EnermyState
{
    public BloodWorm_IdleState(Enemy enemy) : base(enemy){
    }
    
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);
        _emermy.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState(){
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnemyStateType.Move);
        }
    }
}
