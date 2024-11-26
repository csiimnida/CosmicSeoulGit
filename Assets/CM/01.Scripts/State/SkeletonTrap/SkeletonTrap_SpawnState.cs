using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class SkeletonTrap_SpawnState : EnermyState
{
    public SkeletonTrap_SpawnState(Enemy enemy) : base(enemy){
    }

    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Spawn);
        _emermy.ColCompo.enabled = true;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Dynamic;
    }

    public override void UpdateState(){
        if(_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Spawn") 
           && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            _emermy.TransitionState(EnemyStateType.Idle);
    }
}
