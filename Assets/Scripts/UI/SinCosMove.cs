using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class SinCosMove : MonoBehaviour
{
    public RectTransform _rect; 
    public float speed = 1.0f; 
    public float size = 100.0f; 
    public float angleRotate = 1f;
    private float time;

    void Update()
    {
        time += Time.deltaTime * speed;
        float x = size * Mathf.Sin(time);
        float y = size * Mathf.Sin(time) * Mathf.Cos(time);
        _rect.anchoredPosition = new Vector2(x, y);
        _rect.rotation = Quaternion.Euler(0, _rect.localRotation.y, Mathf.Cos(time * -angleRotate));
    }
}
   

  
  





   


