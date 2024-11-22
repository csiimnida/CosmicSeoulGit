using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnable : MonoBehaviour{
    [SerializeField] private string _soundName;
    
    
    private void OnEnable(){
        SoundManager.Instance.PlaySound(_soundName);
    }
}
