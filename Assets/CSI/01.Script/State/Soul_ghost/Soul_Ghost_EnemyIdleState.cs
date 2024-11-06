using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul_Ghost_EnemyIdleState : EnermyState
{
    public Soul_Ghost_EnemyIdleState(Enemy enemy) : base(enemy)
    {
    }

    protected override void EnterState()
    {
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);

    }
    
    public override void UpdateState(){
        
        
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnemyStateType.Move);
        }
    }
}
