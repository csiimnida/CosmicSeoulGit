using System;
using System.Collections;

using UnityEngine;

public class CandyEye : Enemy
{
    protected void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        transform.localScale = DataSo.Size;
        NomallMaterial = sprite.material;

        MaxHp = DataSo.MaxHp;
        NowHp = MaxHp;
        
        foreach (CandyEyeEnermyStateType stateType in Enum.GetValues(typeof(CandyEyeEnermyStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Candy_Eye_Enermy{enumName}State");
            EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
            StateEnum.Add(stateType, state);
        }
        TransitionState(CandyEyeEnermyStateType.Idle);
    }

    protected override void Start(){
        base.Start();
    }

    protected override void Damage_call(float damage){
        NowHp -= damage;
        StartCoroutine(Do_Hit_Effect());
        CombitTimer = 0;
        if (!Combit)
        {
            Combit = true;
            if(currentState == CandyEyeEnermyStateType.Attack1)
                TransitionState(CandyEyeEnermyStateType.Attack1);
            else
                TransitionState(CandyEyeEnermyStateType.Move);
        }

        if (NowHp <= 0)
        {
            print("죽음");
            TransitionState(CandyEyeEnermyStateType.Die);
        }
    }
    private IEnumerator Do_Hit_Effect()
    {
        sprite.material = HitMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = NomallMaterial;
    }
}
public enum CandyEyeEnermyStateType
{
    Idle,
    Move,
    Attack1,
    Die,
}
