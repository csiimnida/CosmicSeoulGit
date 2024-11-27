using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using Random = UnityEngine.Random;
public class SinCosMove : MonoBehaviour
{
    RectTransform _rect;
    float speed = 0.00004f;
    public float size = 0.2f;
    public float angleRotate = 1.15f;
    private float time;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        speed = Random.Range(-2, 2);
        angleRotate = Random.Range(-2, 2);   
    }

    void Update()
    {
        time += Time.realtimeSinceStartup * speed;
        float x = size * Mathf.Sin(time);
        float y = size * Mathf.Sin(time) * Mathf.Cos(time);
        _rect.anchoredPosition = new Vector2(x, y);
        _rect.rotation = Quaternion.Euler(0,-180, Mathf.Cos(time * -angleRotate));
    }
}
   

  
  





   


