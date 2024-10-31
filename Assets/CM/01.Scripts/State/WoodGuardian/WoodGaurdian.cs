using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WoodGaurdian : Enemy
{
    private Dictionary<WoodGuardianStateType, EnermyState> StateEnum = new Dictionary<WoodGuardianStateType, EnermyState>();
    protected void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        NomallMaterial = sprite.material;

        MaxHp = DataSo.MaxHp;
        NowHp = MaxHp;
        
        foreach (WoodGuardianStateType stateType in Enum.GetValues(typeof(WoodGuardianStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"WoodGuardian_{enumName}State");
            EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
            StateEnum.Add(stateType, state);
        }
        TransitionState(WoodGuardianStateType.Idle);
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
public enum WoodGuardianStateType
{
    Idle,
    Move,
    Attack1,
    Attack2,
    Attack3,
    Dead,
}
