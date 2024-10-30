using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyEye : Enermy
{
    protected override void Awake(){
        base.Awake();
    }

    protected override void Start(){
        base.Start();
    }
    
    public void Damage(float damage){
        NowHp -= damage;
        StartCoroutine(Do_Hit_Effect());
        CombitTimer = 0;
        if (!Combit)
        {
            Combit = true;
            TransitionState(EnermyStateType.Move);
        }

        if (NowHp <= 0)
        {
            print("죽음");
            TransitionState(EnermyStateType.Die);
        }
    }

    private IEnumerator Do_Hit_Effect()
    {
        sprite.material = HitMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = NomallMaterial;
    }
}
