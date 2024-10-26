using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyIdleState : EnermyState
{
    public EnermyIdleState(Enermy enermy) : base(enermy)
    {
    
    }

    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Idle);
    }

    public override void UpdateState(){
        
        
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Perception_range,LayerMask.GetMask("Player")))
        {
            _emermy.TransitionState(EnermyStateType.Move);
        }
    }
}
