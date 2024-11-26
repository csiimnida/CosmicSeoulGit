using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using DG.Tweening;
using UnityEngine;

public class Boss_Reaper_Enemy_BloodRequiemState : EnermyState
{
    private float nowHp;
    private bool Started;
    public Boss_Reaper_Enemy_BloodRequiemState(Enemy enemy) : base(enemy)
    {
    }

    protected override void EnterState()
    {
        Started = false;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.BloodRequiem);
        _emermy.BloodRequiemEffect.gameObject.SetActive(true);
        _emermy.SpawnAnimator.gameObject.SetActive(false);
        nowHp = _emermy.NowHp;
        _emermy.NowHp += _emermy.MaxHp * 5 / 100;
        if (_emermy._isSeeRight)
        {
            _emermy.BloodRequiemEffect.DOMoveZ(+50, 0.1f);

        }
        else
        {
            _emermy.BloodRequiemEffect.DOMoveZ(-50, 0.1f);

        }
        _emermy.BloodRequiemEffect.localScale = Vector3.zero;
        _emermy.BloodRequiemEffect.DOMoveY(-3.5f, 8f);
        _emermy.BloodRequiemEffect.DOScale(1.5f, 10f).OnComplete(() =>
        {
            Started = true;
            StartEfect();
        });


    }

    public override void UpdateState()
    {
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;

        if (!Started&&_emermy.NowHp <= nowHp)
        {
            Started = true;
            StartEfect();
        }
    }

    private void StartEfect()
    {
        _emermy.SpawnAnimator.gameObject.SetActive(true);        
        _emermy.BloodRequiemEffect.DOScale(0f, 0.2f).OnComplete(() =>
        {
            _emermy.BloodRequiemEffect.DOScale(0f, 0.3f).OnComplete(() =>
            {
                _emermy.BloodRequiemEffect.DOMoveY(-40, 0.3f);
                

                _emermy.BloodRequiemEffect.DOScale(10f, 0.5f).OnComplete(() =>
                {
                    _emermy.player.Damage(_emermy);
                    _emermy.BloodRequiemEffect.DOScale(10f, 0.5f).OnComplete(() => 
                    { 
                        _emermy.BloodRequiemEffect.gameObject.SetActive(false);
                        _emermy.SpawnAnimator.gameObject.SetActive(false);
                        _emermy.TransitionState(EnemyStateType.Move);
                    });
                    
                });
            });
            

        });
    }
    protected override void ExtiState()
    {
        
    }
    
}
