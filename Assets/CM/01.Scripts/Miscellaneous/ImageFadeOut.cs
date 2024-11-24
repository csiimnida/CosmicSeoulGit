using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour
{
    [SerializeField] private float _fadeIntTime = 3f;
    private AudioSource _backgroundBgm;
    private Image _blackImage;

    private void Awake(){
        MoveNextStage nextStage = GetComponentInParent<MoveNextStage>();
        _backgroundBgm = nextStage.BackgroundBgm;
        _blackImage = GetComponent<Image>();
        _blackImage.color = new Color(0f, 0f, 0f, 2f);
    }

    private void Start(){
        _blackImage.DOFade(0f, _fadeIntTime);
    }
}
