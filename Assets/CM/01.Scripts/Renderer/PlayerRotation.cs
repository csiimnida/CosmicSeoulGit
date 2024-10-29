using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    public void FaceDirection(Vector2 vector)
    {
        if (vector.x > 0)
        {
            transform.parent.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            playerData.IsFlip = false;
        }
        else if (vector.x < 0)
        {
            transform.parent.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            playerData.IsFlip = true;
        }
    }
}
