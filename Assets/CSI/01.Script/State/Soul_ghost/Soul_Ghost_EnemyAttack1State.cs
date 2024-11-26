using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class Soul_Ghost_EnemyAttack1State : EnermyState
{
    public Soul_Ghost_EnemyAttack1State(Enemy enemy) : base(enemy)
    {
    }

    protected override void EnterState()
    {
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack1);
    }

    public override void UpdateState()
    {
        _emermy.RbCompo.velocity = Vector2.zero;

        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        _emermy.isSeeRight = _emermy.transform.position.x > _emermy.player.transform.position.x;
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")) 
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") 
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            
            _emermy.nextState = EnemyStateType.Idle;
            _emermy.TransitionState(EnemyStateType.Idle);
        }
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Attack1;
            _emermy.CoolDowning = true;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.TransitionState(EnemyStateType.Idle);
        }
    }

    protected override void ExtiState()
    {
    }
}
