using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class Boss_Reaper_Enemy_Attack1State : EnermyState
{
    public Boss_Reaper_Enemy_Attack1State(Enemy enemy) : base(enemy)
    {
    }

    private float Persent = 20;
    private float Timer;
    protected override void EnterState()
    {
        if (_emermy._now2Page)
        {
            if (Random.Range(0, 100) <= Persent && Timer >= 3)
            {
                Persent = 20;
                Timer = 0;
                _emermy.TransitionState(EnemyStateType.Teleport);
                return;
            }
            else
            {
                Persent++;
            }
        }
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack1);
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        _emermy.isSeeRight = _emermy.transform.position.x > _emermy.player.transform.position.x;
    }

    public override void UpdateState()
    {
        Timer += Time.deltaTime;
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")) 
                 &&Physics2D.OverlapCircle(_emermy.transform.position, _emermy.SpawnRange,LayerMask.GetMask("Player")) 
                 && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") 
                 && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            
            _emermy.nextState = EnemyStateType.Idle;
            _emermy.TransitionState(EnemyStateType.Spawn);
        }
        if (Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player"))&&
                _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _emermy.nextState = EnemyStateType.Attack1;
            _emermy.CoolDowning = true;
            _emermy.CoolTimeNowTimer = 0;
            _emermy.TransitionState(EnemyStateType.Idle);
            return;
            
        }
        if (!Physics2D.OverlapCircle(_emermy.transform.position, _emermy.DataSo.Attack_range,LayerMask.GetMask("Player")) 
            && _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") 
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
            
            _emermy.nextState = EnemyStateType.Idle;
            _emermy.TransitionState(EnemyStateType.Move);
            return;
        }
    }
}
