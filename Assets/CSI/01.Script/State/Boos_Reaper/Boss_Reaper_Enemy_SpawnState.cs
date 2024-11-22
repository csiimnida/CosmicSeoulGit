using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Reaper_Enemy_SpawnState : EnermyState
{
    private bool Up;
    public Boss_Reaper_Enemy_SpawnState(Enemy enemy) : base(enemy)
    {
    }
    protected override void EnterState()
    {
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        Up = Random.Range(0, 2) == 0;
        _emermy.SpawnAnimator.Play(Up?"Up":"Down");
        _emermy.AnimCompo.PlayAnimaiton(Up?AnimationType.Spawn:AnimationType.SpawnDown);

    }

    public override void UpdateState()
    {

        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,
                LayerMask.GetMask("Player"))
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName(Up?"Spawn":"SpawnDown")
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Idle;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.TransitionState(EnemyStateType.Attack1);
            return;

        }
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName(Up?"Spawn":"SpawnDown") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Spawn;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.CoolDowning = true;
            _emermy.TransitionState(EnemyStateType.Idle);
            return;
        }
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.SpawnRange,LayerMask.GetMask("Player")) 
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName(Up?"Spawn":"SpawnDown") 
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
                 && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName(Up?"Spawn":"SpawnDown") 
                 && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Idle;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.TransitionState(EnemyStateType.Attack1);
        }
    }
}
