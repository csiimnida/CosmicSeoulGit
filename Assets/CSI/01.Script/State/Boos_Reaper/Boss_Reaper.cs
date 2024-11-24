using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

public class Boss_Reaper : Enemy
{
    [field:SerializeField] public Vector2 Attack1Size{ get;private set;}
    [field:SerializeField] public Vector2 TelleportAttackSize{ get;private set;}
    public Transform attack1Pos;
    public Transform telleportAttackPos;
    public AnimatorController _2pageAnim;
    public UnityEvent ChangePage;
    protected void Awake()
    {
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        NomallMaterial = sprite.material;

        MaxHp = DataSo.MaxHp;
        NowHp = MaxHp;
        
        foreach (EnemyStateType stateType in Enum.GetValues(typeof(EnemyStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"Boss_Reaper_Enemy_{enumName}State");
                EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
                StateEnum.Add(stateType, state);
            }
            catch (Exception e)
            {
                //Debug.Log($"{stateType.ToString()}를 찾을수 없습니다");
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
        if (NowHp / MaxHp <= 0.5f && !_now2Page)
        {
            _now2Page = true;
            TransitionState(EnemyStateType.Move);//State 하난 만들어 (2패 전환 State)
            ChangePage?.Invoke();// 너가 만든 배경 작동
            /* 그 스테이트 에서 해야하는것 
             * 
             */
            AnimCompo.Animator.runtimeAnimatorController = _2pageAnim; //너가 만든 배경이 끝났어 그러면 그 스테이트에서 이 코드를 실행 후 Move State로 이동
        }
        if (NowHp <= 0)
        {
            print("죽음");
            TransitionState(EnemyStateType.Dead);
            sprite.material = NomallMaterial;
            Destroy(this);
            return;
        }
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
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position,SpawnRange);//Spawn 범위
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attack1Pos.position, Attack1Size);// 어택1 범위
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(telleportAttackPos.position, TelleportAttackSize);// 어택2 범위

    }
}
