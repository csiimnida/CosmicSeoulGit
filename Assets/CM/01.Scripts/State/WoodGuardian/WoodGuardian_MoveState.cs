using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class WoodGuardian_MoveState : EnermyState
{
    public WoodGuardian_MoveState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Move);
    }

    public override void UpdateState()
    {
        float positionX = (_emermy.player.transform.position- _emermy.transform.position).normalized.x;
        _emermy.RbCompo.velocity = (new Vector2((positionX)*_emermy.DataSo.MoveSpeed,0));
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        _emermy._isSeeRight = _emermy.transform.position.x > _emermy.player.transform.position.x;

        
        
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")))
        {
            if (_emermy.nextState == EnemyStateType.Idle)
            {
                _emermy.nextState = EnemyStateType.Attack1;
            }
            _emermy.TransitionState(_emermy.nextState);
        }
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")) && !_emermy.Combit)
        {
            _emermy.TransitionState(EnemyStateType.Idle);
        }
    }
}
