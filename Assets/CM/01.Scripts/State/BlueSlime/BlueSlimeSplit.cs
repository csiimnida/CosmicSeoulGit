using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimeSplit : MonoBehaviour
{
    [SerializeField] private GameObject ChildSlime;
    
    public void CreateSlime(){
        Instantiate(ChildSlime, new Vector2(transform.position.x - 1f, transform.position.y - 0.3f), Quaternion.identity);
        Instantiate(ChildSlime, new Vector2(transform.position.x + 1f, transform.position.y - 0.3f), Quaternion.identity);
    }
}
