using System.Collections;
using System;
using UnityEngine;

public class WoodGaurdian : Enermy
{
    protected void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        NomallMaterial = sprite.material;

        MaxHp = DataSo.MaxHp;
        NowHp = MaxHp;
        
        foreach (EnemyStateType stateType in Enum.GetValues(typeof(EnemyStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"WoodGuardian_{enumName}State");
            EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
            StateEnum.Add(stateType, state);
        }
        TransitionState(EnemyStateType.Idle);
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
            TransitionState(EnemyStateType.Move);
        }

        if (NowHp <= 0)
        {
            print("죽음");
            TransitionState(EnemyStateType.Die);
        }
    }
    private IEnumerator Do_Hit_Effect()
    {
        sprite.material = HitMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = NomallMaterial;
    }
}
