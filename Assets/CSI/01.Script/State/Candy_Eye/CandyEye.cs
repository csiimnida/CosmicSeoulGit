using System;
using System.Collections;

using UnityEngine;

public class CandyEye : Enermy
{
    protected void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RotCompo = GetComponentInChildren<PlayerRotation>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        transform.localScale = DataSo.Size;
        NomallMaterial = sprite.material;

        MaxHp = DataSo.MaxHp;
        NowHp = MaxHp;
        
        foreach (EnermyStateType stateType in Enum.GetValues(typeof(EnermyStateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Enermy{enumName}State");
            EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
            StateEnum.Add(stateType, state);
        }
        TransitionState(EnermyStateType.Idle);
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
