using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public void PlaySound(){
        SoundManager.Instance.PlaySound("Walking");
    }
}
