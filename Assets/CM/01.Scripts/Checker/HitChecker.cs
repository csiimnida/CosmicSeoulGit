using Cinemachine;
using CSI._01.Script.Monster;
using UnityEngine;

public class HitChecker : MonoBehaviour{

    [SerializeField] private Player _player;
    
    [SerializeField] private Vector2 Attack1Size;
    [SerializeField] private Vector2 Attack2Size;
    [SerializeField] private Vector2 Skill1Size;
    
    [SerializeField] private Transform Attack1Transform;
    [SerializeField] private Transform Attack2Transform;
    [SerializeField] private Transform Skill1Transform;
    
    [SerializeField] private Vector2 _shakePower;
    [SerializeField] private float _shakeDuration;
    private CinemachineImpulseSource _impulseSource;

    private Collider2D Attack1Collider;
    private Collider2D Attack2Collider;
    private Collider2D Skill1Collider;
    
    private void Awake(){
        _impulseSource = GetComponentInParent<CinemachineImpulseSource>();
    }

    public void CheckAttack1(){
        Collider2D collider = Physics2D.OverlapBox(Attack1Transform.position, Attack1Size,0, LayerMask.GetMask("Enemy"));
        if (collider != null)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Shake();
                enemy.Damage(_player.PlayerData.Damage);
            }
        }
    }
    
    public void CheckAttack2(){
        Collider2D collider = Physics2D.OverlapBox(Attack1Transform.position, Attack1Size,0, LayerMask.GetMask("Enemy"));
        if (collider != null)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Shake();
                enemy.Damage(_player.PlayerData.Damage);
            }
        }
    }
    
    public void CheckSkill1(){
        Collider2D collider = Physics2D.OverlapBox(Attack1Transform.position, Attack1Size,0, LayerMask.GetMask("Enemy"));
        if (collider != null)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Shake();
                enemy.Damage(_player.PlayerData.Damage * _player.PlayerData.Skill1Multiple);
            }
        }
    }

    private void Shake(){
        _impulseSource.m_DefaultVelocity = _shakePower;
        _impulseSource.m_ImpulseDefinition.m_ImpulseDuration = _shakeDuration;
        _impulseSource.GenerateImpulse();
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Attack1Transform.position, Attack1Size);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Attack2Transform.position, Attack2Size);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Skill1Transform.position, Skill1Size);
    }
}
