using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper_EnemyAttack1State : EnermyState
{
    public Reaper_EnemyAttack1State(Enemy enemy) : base(enemy)
    {
    }
    
    protected override void EnterState()
    {
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack1);
    }

    public override void UpdateState()
    {
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Attack2;
            _emermy.CoolDowning = true;
            _emermy.CoolTimeNowTimer = _emermy.CoolTimeMaxTimer;
            _emermy.TransitionState(EnemyStateType.Idle);
            return;
        }
    }

    protected override void ExtiState()
    {
        
    }
}
