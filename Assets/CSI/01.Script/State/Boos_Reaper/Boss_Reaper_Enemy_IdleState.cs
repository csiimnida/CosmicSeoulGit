using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class Boss_Reaper_Enemy_IdleState : EnermyState
{
    private LayerMask _player;
    public Boss_Reaper_Enemy_IdleState(Enemy enemy) : base(enemy)
    {
        _player = LayerMask.GetMask("Player");
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);
        _emermy.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState()
    {
        
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,
                _player))//완전히 나갔을때
        {
            _emermy.CoolDowning = false;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.nextState = EnemyStateType.Idle;
            _emermy.TransitionState(EnemyStateType.Idle);
            return;

        }
        if(!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,_player))
        {
            if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.SpawnRange,_player))
            {
                if (_emermy.CoolDowning)
                {
                    return;
                }
                _emermy.TransitionState(EnemyStateType.Spawn);
                _emermy.CoolDowning = false;
                _emermy.CoolTimeNowTimer = 0;
                return;

            }
        }
        if(!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,_player))
        {
            if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.SpawnRange,_player))
            {
                if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,
                        _player)) //Move 범위
                {
                    _emermy.TransitionState(EnemyStateType.Move);
                    _emermy.CoolDowning = false;
                    _emermy.CoolTimeNowTimer = 0;
                    return;
                }
            }
        }

    }
}
