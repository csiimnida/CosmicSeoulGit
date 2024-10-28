using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneGenerner : MonoBehaviour
{
    public Transform target;

    public void SpawnEye()
    {
        EyeBall eye = PoolManager.Instance.Pop("Eye") as EyeBall;
        eye.transform.position = target.position;
        eye.transform.localScale = target.parent.localScale;
    }
}
