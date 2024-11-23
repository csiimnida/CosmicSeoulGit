using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCheacker : MonoBehaviour
{
    PlayerMove groundCheak;
    LayerMask mask;
    CapsuleCollider2D boxCollider;
   public float Extrude = .5f;
    private void Awake()
    {
      
        //groundCheak.OnCheakGround += CheakGround;
        boxCollider = GetComponent<CapsuleCollider2D>();
    }
    public void CheakGround()
    {
        Color color;

        RaycastHit2D hit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + Extrude);

        if (hit.collider != null)
        {
            color = Color.green;
        }

        else
        {
            color = Color.red;
        }

        Debug.DrawLine(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + Extrude), color);
    }

    private void Update()
    {
       CheakGround();
    }

}
