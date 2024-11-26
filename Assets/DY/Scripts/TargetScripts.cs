using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TargetScripts : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private Transform endtarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.DOMove(target.position, 0.1f);
    }
}
