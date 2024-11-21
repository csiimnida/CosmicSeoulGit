using UnityEngine;

public class Candy_Eye_EnermyDeadState : EnermyState
{
    public Candy_Eye_EnermyDeadState(Enemy enemy) : base(enemy)
    {
    }

    protected override void EnterState()
    {
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.ColCompo.enabled = false;
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        _emermy.player.GetHp();
        _emermy.player.GetExp(_emermy.DataSo);
    }
    public override void UpdateState()
    {
        
    }
}
