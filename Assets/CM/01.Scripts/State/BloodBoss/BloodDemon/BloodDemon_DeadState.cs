using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDemon_DeadState : EnermyState
{
    public BloodDemon_DeadState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        EnemyManager.Instance.Start2Page();
    }
}
