using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGuardian_IdleState : EnermyState
{
    public WoodGuardian_IdleState(Enemy enemy) : base(enemy){
    }

    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);
        _emermy.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState(){
        /*if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnemyStateType.Move);
        }*/

        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,
                LayerMask.GetMask("Player")))
        {
            if (!_emermy.CoolDowning)
            {
                //_emermy.TransitionState(EnemyStateType.Attack1);

                _emermy.TransitionState(_emermy.nextState);
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

        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,
                LayerMask.GetMask("Player")))//완전히 나갔을때
        {
            _emermy.CoolDowning = false;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.nextState = EnemyStateType.Idle;
            _emermy.TransitionState(EnemyStateType.Idle);
        }
    }
}
