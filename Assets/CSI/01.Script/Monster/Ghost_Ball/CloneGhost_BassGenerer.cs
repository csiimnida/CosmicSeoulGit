using System.Collections;
using System.Collections.Generic;
using CSI._01.Script.Monster;
using UnityEngine;

public class CloneGhost_BassGenerer : MonoBehaviour
{
    public Transform target;
    private Soul _soul;

    private void Start(){
        _soul = GetComponentInParent<Soul>();
    }
    public void SpawnGhostBall()
    {
        Ghost_Ball eye = PoolManager.Instance.Pop("Ghost_Ball") as Ghost_Ball;
        eye.transform.rotation = target.parent.rotation;
        eye.transform.position = target.position;
        eye._isSeeRight = _soul.isSeeRight;
        eye.enermyData = target.parent.GetComponent<Enemy>().DataSo;
        eye.Rotate();
    }


}
