using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VirtualCameraSetting : MonoBehaviour
{
    private Transform target;
    private CinemachineVirtualCamera cam;
    
    private void Awake(){
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start(){
        target = GameManager.Instance.Player.transform.Find("CameraPosition").transform;
        cam.Follow = target;
    }
}
