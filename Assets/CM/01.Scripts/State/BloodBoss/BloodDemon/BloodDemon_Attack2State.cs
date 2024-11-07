using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDemon_Attack2State : EnermyState
{
    public BloodDemon_Attack2State(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack2);
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
    }

    public override void UpdateState(){
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Attack1;
            _emermy.CoolDowning = true;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.TransitionState(EnemyStateType.Idle);
            return;
        }
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2")
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            
            _emermy.TransitionState(EnemyStateType.Idle);
        }
    }
}
