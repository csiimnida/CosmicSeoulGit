using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake(){
        _slider = GetComponent<Slider>();
    }

    private void OnEnable(){
        _slider.value = GameManager.Instance.Player.Exp;
    }

    public void ExpBarValueChange(int exp){
        _slider.value = exp;
    }

    public void ExpBarMaxValueChange(int maxExp){
        _slider.maxValue = maxExp;
        _slider.value = 0;
    }
    
}
