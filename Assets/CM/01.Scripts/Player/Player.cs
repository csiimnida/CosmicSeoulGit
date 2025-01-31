using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using CSI._01.Script.Monster;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader InputCompo;
    [field: SerializeField] public PlayerDataSO PlayerData;
    
    public AnimationChange AnimCompo {get ; private set;}
    public PlayerRotation RotCompo {get ; private set;}
    public Rigidbody2D RbCompo {get ; private set;}
    public Collider2D ColCompo {get ; private set;}
    
    public SpriteRenderer SpriteCompo {get ; private set;}

    public GroundChecker GroundChecker {get ; private set;}

    private Dictionary<PlayerStateType, PlayerState> StateEnum = new Dictionary<PlayerStateType, PlayerState>();
    public PlayerStateType currentState{ get; private set; }
    
    private CinemachineImpulseSource impulseSource;

    public float NowHP { get; private set; }

    private Material NormalMat;
    [SerializeField] private Material HitMat;
    
    public event Action OnDeath;

    public int Exp = 0;
    public int MaxExp = 100;

    public Transform Panal;

    public UnityEvent<int> OnTakeExp;

    private void Awake(){
        AnimCompo = GetComponentInChildren<AnimationChange>();
        RotCompo = GetComponentInChildren<PlayerRotation>();
        RbCompo= GetComponent<Rigidbody2D>();
        ColCompo = GetComponent<Collider2D>();
        GroundChecker = GetComponentInChildren<GroundChecker>();
        SpriteCompo = GetComponentInChildren<SpriteRenderer>();
        impulseSource = GetComponent<CinemachineImpulseSource>();

        NowHP = PlayerData.Hp;
        
        foreach (PlayerStateType stateType in Enum.GetValues(typeof(PlayerStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"{enumName}State");
                PlayerState state = Activator.CreateInstance(t, new object[] { this }) as PlayerState;
                StateEnum.Add(stateType, state);

            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        TransitionState(PlayerStateType.Idle);
    }

    private void Start()
    {
        InputCompo.OnMoveEvent += RotCompo.FaceDirection;
        PlayerData.IsFlip = false;
        NormalMat = SpriteCompo.material;
        
        //DontDestroyOnLoad(gameObject);
    }
    
    

    public void TransitionState(PlayerStateType newState){
        StateEnum[currentState].Exit();
        currentState = newState;
        StateEnum[currentState].Enter();
    }

    private void Update()
    {
        StateEnum[currentState].UpdateState();
    }

    private void FixedUpdate()
    {
        StateEnum[currentState].FixedUpdateState();
    }

    public void Damage(Enemy enemy) => SumDamage(enemy.isSeeRight, enemy.DataSo.AttackPower, enemy.DataSo);

    public void Damage(EyeBall script) => SumDamage(script._isSeeRight, script.enermyData.AttackPower, script.enermyData);
    public void Damage(Ghost_Ball script) => SumDamage(script._isSeeRight, script.enermyData.AttackPower, script.enermyData);

    public void Damage(Reaper_Ball script) => SumDamage(script._isSeeRight, script.enermyData.AttackPower, script.enermyData);

    private void SumDamage(bool isSeeRight, float attackPwoer, EnermyDataSO enermyDataSo)
    {
        if (currentState == PlayerStateType.Block)
        {
            if (!isSeeRight && PlayerData.IsFlip)
            {
                TransitionState(PlayerStateType.BlockImpact);
                return;
            }

            if (isSeeRight && !PlayerData.IsFlip)
            {
                TransitionState(PlayerStateType.BlockImpact);
                return;
            }
        }
        if(currentState == PlayerStateType.Roll) return;
        
        NowHP -= attackPwoer;
        if (NowHP > 0)
        {
            SoundManager.Instance.PlaySound("Hurt");
            StartCoroutine(Do_Hit_Effect());
            ShakeCamera(enermyDataSo);
        }
        else if (NowHP <= 0)
        {
            
            Debug.Log("호출");
            TransitionState(PlayerStateType.Death);
            ShakeCamera(enermyDataSo);
            CardManager.Instance.volumes[1].SetActive(true);
            CardManager.Instance.volumes[0].SetActive(false);
            OnDeath?.Invoke();
            CardManager.Instance.volumes[1].GetComponent<Volume>().enabled = true;
        }
    }
    
    private IEnumerator Do_Hit_Effect()
    {
        SpriteCompo.material = HitMat;
        yield return new WaitForSeconds(0.1f);
        SpriteCompo.material = NormalMat;
    }

    public void GetExp(EnermyDataSO data){
        Exp += data.ExpValue;
        OnTakeExp?.Invoke(Exp);
    }

    public void GetHpUp(){
        NowHP += PlayerData.Hp * 0.05f;
    }

    public void ResetExp(){
        Exp = 0;
    }

    private void OnDisable()
    {
        Destroy(CardManager.Instance.gameObject);

    }

    private void ShakeCamera(EnermyDataSO data){
        impulseSource.m_DefaultVelocity = data.CameraShakePower;
        impulseSource.m_ImpulseDefinition.m_ImpulseDuration = data.CameraShakeDuration;
        impulseSource.GenerateImpulse();
    }

    public void OnDeathEventInvoke(){
        OnDeath?.Invoke();
    }

    private void OnDestroy(){
        InputCompo.OnMoveEvent -= RotCompo.FaceDirection;
        StateEnum[currentState].Exit();
    }

    public float GetHP(){
        return NowHP;
    }
}
