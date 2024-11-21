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

    public void ExpBarValueChange(int exp){
        _slider.value = exp;
        Debug.Log("값채인지");
    }

    public void ExpBarMaxValueChange(int maxExp){
        _slider.maxValue = maxExp;
        _slider.value = 0;
        Debug.Log("맥스값 증가");
    }
    
}
