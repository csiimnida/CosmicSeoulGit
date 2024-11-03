using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkeletonTrap : Enemy
{
    [field:SerializeField] public Vector2 Attack1Size{ get;private set;}
    private int SpawnCount = 0;

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
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"SkeletonTrap_{enumName}State");
                EnermyState state = Activator.CreateInstance(t, new object[] { this }) as EnermyState;
                StateEnum.Add(stateType, state);
            }
            catch (Exception e)
            {
                Debug.Log($"{stateType.ToString()}를 찾을수 없습니다");
            }
        }
    }

    protected override void Start(){
        base.Start();
        ColCompo.enabled = false;
        RbCompo.bodyType = RigidbodyType2D.Static;
    }

    protected override void Damage_call(float damage){
        NowHp -= damage;
        StartCoroutine(Do_Hit_Effect());
        CombitTimer = 0;
        if (!Combit)
        {
            Combit = true;
            if(currentState == EnemyStateType.Attack1||currentState == EnemyStateType.Attack2||currentState == EnemyStateType.Attack3)
                return;
            else
                TransitionState(EnemyStateType.Move);

        }

        if (NowHp <= 0)
        {
            print("죽음");
            TransitionState(EnemyStateType.Dead);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, Attack1Size);// 어택1 범위
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,SpawnRange);
    }

    private void LateUpdate(){
        if (Physics2D.OverlapCircle(transform.position, SpawnRange, LayerMask.GetMask("Player")) && SpawnCount == 0)
        {
            TransitionState(EnemyStateType.Spawn);
            SpawnCount++;
        }
    }
}
