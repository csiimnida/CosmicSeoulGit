using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCat_DeadState : EnermyState
{
    public BombCat_DeadState(Enemy enemy) : base(enemy){
    }
    
    protected override void EnterState(){
        _emermy.AnimCompo.PlayAnimaiton(AnimationType.Death);
        _emermy.sprite.color = new Color(1f, 1f, 1f, 0f);
        _emermy.RbCompo.bodyType = RigidbodyType2D.Static;
        _emermy.ColCompo.enabled = false;
        _emermy.sprite.enabled = false;
    }
}
