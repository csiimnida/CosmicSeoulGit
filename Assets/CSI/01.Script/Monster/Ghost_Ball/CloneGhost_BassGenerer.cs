using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneGhost_BassGenerer : MonoBehaviour
{
    public Transform target;

    public void SpawnGhostBall()
    {
        Ghost_Ball eye = PoolManager.Instance.Pop("Ghost_Ball") as Ghost_Ball;
        eye.transform.rotation = target.parent.rotation;
        eye.transform.position = target.position;
        eye.Damage = target.parent.GetComponent<Enemy>().DataSo.AttackPower;
        eye.Rotate();
    }


}
