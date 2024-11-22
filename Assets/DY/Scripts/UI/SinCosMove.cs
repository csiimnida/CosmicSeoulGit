using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using Random = UnityEngine.Random;
public class SinCosMove : MonoBehaviour
{
    RectTransform _rect;
    float speed = 0;
    public float size = 100.0f;
    public float angleRotate = 0;
    private float time;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        speed = Random.Range(1, 8);
        angleRotate = Random.Range(1, 3);   
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        float x = size * Mathf.Sin(time);
        float y = size * Mathf.Sin(time) * Mathf.Cos(time);
        _rect.anchoredPosition = new Vector2(x, y);
        _rect.rotation = Quaternion.Euler(0,-180, Mathf.Cos(time * -angleRotate));
    }
}
   

  
  





   


