using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private string walkSoundName = "Walking";
    public void PlayWalkSound(){
        SoundManager.Instance.PlaySound(walkSoundName);
    }
}
