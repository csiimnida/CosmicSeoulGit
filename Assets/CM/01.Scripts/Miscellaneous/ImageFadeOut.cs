using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour
{
    [SerializeField] private float _fadeIntTime = 3f;
    private Image _blackImage;

    private void Awake(){
        _blackImage = GetComponent<Image>();
        _blackImage.color = new Color(1f, 1f, 1f, 1f);
    }

    private void Start(){
        _blackImage.DOFade(0f, _fadeIntTime);
    }
}
