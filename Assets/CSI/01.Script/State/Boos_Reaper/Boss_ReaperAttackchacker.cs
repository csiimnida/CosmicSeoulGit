using System.Collections.Generic;
using UnityEngine;

public class Boss_ReaperAttackchacker : MonoBehaviour
{
    private Boss_Reaper _reaper;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _target;
    public List<Transform> _down_Spawn_poss;
    private void Start(){
        _reaper = GetComponentInParent<Boss_Reaper>();

    }

    public void Attack1Checker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_reaper.attack1Pos.position, _reaper.Attack1Size, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_reaper);
        }
    }

    public void Spawn()
    {
        Reaper_Ball ball = PoolManager.Instance.Pop("Reaper_Ball") as Reaper_Ball;
        ball.transform.rotation = _target.rotation;
        ball.transform.position = _target.position;
        ball._isSeeRight = _reaper._isSeeRight;
        ball.speed = 10f;
        ball.enermyData = _target.parent.GetComponent<Enemy>().DataSo;
    }

    public void SpawnDown()
    {
        for (int i = 0; i < _down_Spawn_poss.Count; i++)
        {
            Reaper_Ball ball = PoolManager.Instance.Pop("Reaper_Ball") as Reaper_Ball;
            ball.transform.position = _down_Spawn_poss[i].position;
            ball.transform.rotation = _down_Spawn_poss[i].rotation;
            ball._isSeeRight = _reaper._isSeeRight;
            ball.speed = 5f;
            ball.enermyData = _target.parent.GetComponent<Enemy>().DataSo;
        }
    }
    public void TelleportAttackChecker(){
        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(_reaper.telleportAttackPos.position, _reaper.TelleportAttackSize, _layerMask);
        foreach (var collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if(player != null && !player.ColCompo.isTrigger)
                player.Damage(_reaper);
        }
    }

}
