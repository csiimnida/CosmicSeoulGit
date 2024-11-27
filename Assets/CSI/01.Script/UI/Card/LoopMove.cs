using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMove : MonoBehaviour
{
    Transform _rect;
    public float speed = 0;
    public float size = 1.0f;
    public float angleRotate = 0;
    private float time;
    public bool Play;

    private void Awake()
    {
        _rect = transform;
    }
    

    void Update()
    {
        if(!Play) return;
        time += Time.realtimeSinceStartup * speed;
        float x = size * Mathf.Sin(time);
        float y = size * Mathf.Sin(time) * Mathf.Cos(time);
        _rect.position = new Vector2(x+transform.parent.position.x, y+transform.parent.position.y);
        _rect.rotation = Quaternion.Euler(_rect.rotation.eulerAngles.x,_rect.rotation.eulerAngles.y, Mathf.Cos(time * -angleRotate));
    }


}
