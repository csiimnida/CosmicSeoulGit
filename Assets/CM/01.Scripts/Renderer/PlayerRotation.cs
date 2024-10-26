using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void FaceDirection(Vector2 vector)
    {
        if(vector.x > 0)
            transform.parent.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        else if(vector.x < 0)
            transform.parent.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
