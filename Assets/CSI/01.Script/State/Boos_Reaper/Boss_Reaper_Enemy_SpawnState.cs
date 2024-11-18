using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Reaper_Enemy_SpawnState : EnermyState
{
    public Boss_Reaper_Enemy_SpawnState(Enemy enemy) : base(enemy)
    {
    }
    protected override void EnterState()
    {
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Spawn);
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
    }

    public override void UpdateState()
    {

        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,
                LayerMask.GetMask("Player"))
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Spawn")
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Attack1;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.TransitionState(EnemyStateType.Attack1);
            return;

        }
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Spawn") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Spawn;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.CoolDowning = true;
            _emermy.TransitionState(EnemyStateType.Idle);
            return;
        }
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.SpawnRange,LayerMask.GetMask("Player")) 
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Spawn") 
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            if (_emermy.Combit)
            {
                if (_emermy.player.GetComponent<Player>().GetHP() <= 0)
                {
                    _emermy.TransitionState(EnemyStateType.Idle);
                    return;
                }
            }
            _emermy.nextState = EnemyStateType.Move;
            _emermy.TransitionState(EnemyStateType.Move);
        }
        else if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")) 
                 && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Spawn") 
                 && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Attack1;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.TransitionState(EnemyStateType.Attack1);
        }
    }
}
