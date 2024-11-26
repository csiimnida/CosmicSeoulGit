using System.Collections;
using CSI._01.Script.Monster;
using UnityEngine;
using DG.Tweening;
public class Soul_Ghost_EnemyAvoidState : EnermyState
{
    private float Timer,goalTimer = 3f;
    public Soul_Ghost_EnemyAvoidState(Enemy enemy) : base(enemy)
    {
    }
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Move);
    }
    public override void UpdateState()
    {
        Timer += Time.deltaTime;
        float positionX = ( _emermy.transform.position - _emermy.player.transform.position).normalized.x;
        _emermy.RbCompo.velocity = (new Vector2((positionX)*_emermy.DataSo.MoveSpeed,0));
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 0 : 180,Vector3.up);
        _emermy._isSeeRight = _emermy.transform.position.x > _emermy.player.transform.position.x;

        CheckTimer();
    }
    private void CheckTimer()
    {
        if (Timer >= goalTimer)
        {
            _emermy.TransitionState(EnemyStateType.Idle);
            
        }
    }

    protected override void ExtiState()
    {
        base.ExtiState();
        _emermy.sprite.DOFade(1, 0.5f).SetEase(Ease.OutCubic);

    }
}
