using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EndingCreditText : MonoBehaviour{
    private TextMeshProUGUI _text;
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration;

    private void Awake(){
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start(){
        _text.rectTransform.DOMoveY(_target.position.y, _duration).SetEase(Ease.Linear);
    }
}
