using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour
{
    [SerializeField] private float _fadeInTime = 3f;
    [SerializeField] private AudioSource _backgroundBgm;
    private Image _blackImage;

    private void Awake(){
        _blackImage = GetComponent<Image>();
        _blackImage.color = new Color(0f, 0f, 0f, 2f);
    }

    private void Start(){
        _blackImage.DOFade(0f, _fadeInTime);
        StartCoroutine(SoundVolumeUp());
    }

    private IEnumerator SoundVolumeUp(){
        _backgroundBgm.volume = 0f;
        for (int i = 0; i < 100; i++)
        {
            _backgroundBgm.volume += 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(_fadeInTime + 0.5f);
    }
}
