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
        
        foreach (EnemyStateType stateType in Enum.GetValues(typeof(EnemyStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"Candy_Eye_Enermy{enumName}State");
                EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
                StateEnum.Add(stateType, state);
            }
            catch (Exception e)
            {
                Debug.LogError($"{stateType.ToString()}를 찾을수 없습니다");
            }
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
            if(currentState == EnemyStateType.Attack1)
                TransitionState(EnemyStateType.Attack1);
            else
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

