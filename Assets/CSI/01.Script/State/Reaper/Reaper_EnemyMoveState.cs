using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class Reaper_EnemyMoveState : EnermyState
{
    public Reaper_EnemyMoveState(Enemy enemy) : base(enemy)
    {
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Move); 
    }

    public override void UpdateState()
    {
        float positionX = (_emermy.player.transform.position- _emermy.transform.position).normalized.x;
        _emermy.RbCompo.velocity = (new Vector2((positionX)*_emermy.DataSo.MoveSpeed,0));
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        _emermy.isSeeRight = _emermy.transform.position.x > _emermy.player.transform.position.x;
        
        
        
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnemyStateType.Attack1);
        }
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")) && !_emermy.Combit)
        {
            _emermy.TransitionState(EnemyStateType.Idle);
        }
    }
}
