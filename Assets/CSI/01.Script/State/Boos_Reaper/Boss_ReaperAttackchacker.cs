using UnityEngine;

public class Boss_ReaperAttackchacker : MonoBehaviour
{
    private Boss_Reaper _reaper;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _target;

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
                player.Damage(_reaper.DataSo, _reaper.DataSo.AttackPower);
        }
    }

    public void Spawn()
    {
        Reaper_Ball ball = PoolManager.Instance.Pop("Reaper_Ball") as Reaper_Ball;
        ball.transform.rotation = _target.rotation;
        ball.transform.position = _target.position;
        ball.enermyData = _target.parent.GetComponent<Enemy>().DataSo;
        ball.Rotate();
    }


}
