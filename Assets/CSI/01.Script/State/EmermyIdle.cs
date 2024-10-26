using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyIdleState : EmermyState
{
    public EnermyIdleState(Enermy enermy) : base(enermy)
    {
    
    }

    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);
    }

    public override void UpdateState(){
        /*if(Mathf.Abs(_emermy.InputCompo.InputVector.x) > 0)
            _emermy.TransitionState(PlayerStateType.Move);*/
    }
}
