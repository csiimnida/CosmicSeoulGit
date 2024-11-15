using UnityEngine;

public class CloneEyeGenerner : MonoBehaviour
{
    public Transform target;

    public void SpawnEye()
    {
        EyeBall eye = PoolManager.Instance.Pop("Eye") as EyeBall;
        eye.transform.rotation = target.parent.rotation;
        eye.transform.position = target.position;
        eye.enermyData = target.parent.GetComponent<Enemy>().DataSo;
        eye.Rotate();
    }

    
}
