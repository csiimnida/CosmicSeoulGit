using CSI._01.Script.Monster;
using UnityEngine;


public class Candy_Eye_EnermyAttack1State : EnermyState
{
    public Candy_Eye_EnermyAttack1State(Enemy enemy) : base(enemy)
    {
        
    }
    protected override void EnterState()
    {
        Debug.Log("Attack State Entered");
        _emermy.RbCompo.velocity = Vector2.zero;
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Attack1);
    }

    public override void UpdateState()
    {
        _emermy.transform.localRotation = Quaternion.AngleAxis(_emermy.transform.position.x > _emermy.player.transform.position.x ? 180 : 0,Vector3.up);
        _emermy._isSeeRight = _emermy.transform.position.x > _emermy.player.transform.position.x;
    }

    protected override void ExtiState()
    {
        
    }
}