using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class Boss_Reaper_Enemy_DeadState : EnermyState
{
    public Boss_Reaper_Enemy_DeadState(Enemy enemy) : base(enemy)
    {
    }
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
    }
}
