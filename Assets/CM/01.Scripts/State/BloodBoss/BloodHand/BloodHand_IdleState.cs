using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class BloodHand_IdleState : EnermyState
{
    public BloodHand_IdleState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);
        _emermy.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState(){
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnemyStateType.Attack1);
        }
    }
}
