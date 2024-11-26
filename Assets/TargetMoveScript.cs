using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveScript : MonoBehaviour
{
    [SerializeField] private GameObject Camara;
    private float DIr;
    private float trmz;

    private void Start()
    {
        trmz = transform.position.z;
        DIr = Vector2.Distance(transform.position , Camara.transform.position);
    }

    private void Update()
    {
        transform.position = new Vector3(Camara.transform.position.x +  DIr, transform.position.y,trmz);
        
    }
}
