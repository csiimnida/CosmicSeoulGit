using CSI._01.Script.Monster;
using UnityEngine;

public class CloneEyeGenerner : MonoBehaviour
{
    public Transform target;
    private CandyEye _candyEye;

    private void Start(){
        _candyEye = GetComponentInParent<CandyEye>();
    }
    public void SpawnEye()
    {
        EyeBall eye = PoolManager.Instance.Pop("Eye") as EyeBall;
        eye.transform.rotation = target.parent.rotation;
        eye.transform.position = target.position;
        eye._isSeeRight = _candyEye.isSeeRight;
        eye.enermyData = target.parent.GetComponent<Enemy>().DataSo;
        eye.Rotate();
    }

    
}
