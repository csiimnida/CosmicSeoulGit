using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTrap_DeadState : EnermyState
{
    public SkeletonTrap_DeadState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        _emermy.player.GetHp();
        _emermy.player.GetExp(_emermy.DataSo);
    }
}
