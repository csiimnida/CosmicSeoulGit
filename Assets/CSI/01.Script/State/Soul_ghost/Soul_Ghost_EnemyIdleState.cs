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
    
    public override void UpdateState()
    {
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,
                LayerMask.GetMask("Player")))
        {
            if (!_emermy.CoolDowning)
            {
                _emermy.TransitionState(EnemyStateType.Move);

            }
        }
        if(!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")))
        {
            if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")))
            {
                _emermy.TransitionState(EnemyStateType.Move);
                _emermy.CoolDowning = false;
                _emermy.CoolTimeNowTimer = 0;
            }
        }

        if (_emermy.CoolDowning == true) return;
        /*if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,
                LayerMask.GetMask("Player")))
        {
            
        }*/
    }
}
