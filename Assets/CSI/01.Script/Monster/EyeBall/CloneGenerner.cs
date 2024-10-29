using UnityEngine;

public class CloneGenerner : MonoBehaviour
{
    public Transform target;

    public void SpawnEye()
    {
        EyeBall eye = PoolManager.Instance.Pop("Eye") as EyeBall;
        eye.transform.rotation = target.parent.rotation;
        eye.transform.position = target.position;
        eye.Damage = target.parent.GetComponent<Enermy>().DataSo.AttackPower;
        eye.Rotate();
    }

    
}
