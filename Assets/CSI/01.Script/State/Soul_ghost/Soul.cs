using System;
using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;
using DG.Tweening;


public class Soul : Enemy
{
    
    private bool FirstAttack;

    protected override void Awake(){
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
                Type t = Type.GetType($"Soul_Ghost_Enemy{enumName}State");
                EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
                StateEnum.Add(stateType, state);
            }
            catch (Exception e)
            {
                //ignored
            }
        }
        TransitionState(EnemyStateType.Idle);
    }

    protected override void Start(){
        base.Start();
    }

    
    protected override void Damage_call(float damage){
        if (!FirstAttack)
        {
            FirstAttack = true;
            sprite.DOFade(0.1f, 0.5f).SetEase(Ease.OutCubic);
            TransitionState(EnemyStateType.Avoid);
            return;
        }
        NowHp -= damage;
        StartCoroutine(Do_Hit_Effect());

        if (NowHp <= 0)
        {
            print("죽음");
            TransitionState(EnemyStateType.Dead);
            sprite.material = NomallMaterial;
            Destroy(this);
        }
        if(CoolDowning) return;
    }
    private IEnumerator Do_Hit_Effect()
    {
        sprite.material = HitMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = NomallMaterial;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,DataSo.Perception_range);//감지 범위
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,DataSo.Attack_range);//공격 범위
    }
}
