using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using DG.Tweening;
using UnityEngine;

public class Boss_Reaper_Enemy_TeleportState : EnermyState
{
    
    private int patsent;
    private Vector3 pos;
    private Vector3 plrpos;
    private bool StartedTelleport;
    class CustomTimer
    {
        public float NowTime = 0;
        public float MaxTime = 0;
        public bool StartTime;
        
    }
    CustomTimer TelleportWait = new CustomTimer();

    public Boss_Reaper_Enemy_TeleportState(Enemy enemy) : base(enemy)
    {
    }
    protected override void EnterState()
    {
        TelleportWait.MaxTime = 1;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.TelleportStart);

    }

    public override void UpdateState()
    {
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        _emermy.isSeeRight = _emermy.transform.position.x > _emermy.player.transform.position.x;
        if (TelleportWait.StartTime)
        {
            if (TelleportWait.NowTime >= TelleportWait.MaxTime)
            {
                TelleportWait.NowTime = 0;
                TelleportWait.StartTime = false;
                telleport();
            }
            TelleportWait.NowTime += Time.deltaTime;
        }
        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("TelleportStart") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f&&!StartedTelleport)
        {
            StartedTelleport = true;
            _emermy.sprite.DOFade(0f, 0.3f).SetEase(Ease.OutCubic);
            TelleportWait.StartTime = true;
        }

        if (_emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).IsName("TelleportEnd") &&
            _emermy.AnimCompo.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.1f)
        {
            StartedTelleport = false;

            _emermy.TransitionState(EnemyStateType.Attack1);
        }
    }

    private void telleport()
    {
        plrpos = _emermy.player.transform.position;
        var Rot = _emermy.player.PlayerData.IsFlip;
        pos = new Vector3((plrpos.x+2 * (Rot? 1 : -1)), plrpos.y, plrpos.z);
        _emermy.gameObject.transform.position = pos;
        _emermy.sprite.DOFade(1f, 0.1f).SetEase(Ease.OutCubic);
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.TelleportEnd);


    }
}
