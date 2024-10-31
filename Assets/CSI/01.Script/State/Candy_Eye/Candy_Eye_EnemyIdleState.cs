using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Candy_Eye_EnermyIdleState : EnermyState
{
    public Candy_Eye_EnermyIdleState(Enemy enemy) : base(enemy)
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);

    }

    protected override void EnterState()
    {
        Debug.Log("Idle실행");
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);

    }

    public override void UpdateState(){
        
        
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(CandyEyeEnermyStateType.Move);
        }
    }
}
