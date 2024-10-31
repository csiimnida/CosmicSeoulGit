using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGuardian_Attack2State : EnermyState
{
    public WoodGuardian_Attack2State(Enemy enemy) : base(enemy){
    }

    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack2);
    }

    public override void UpdateState(){
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2")
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.TransitionState(EnemyStateType.Idle);
        }
    }
}
