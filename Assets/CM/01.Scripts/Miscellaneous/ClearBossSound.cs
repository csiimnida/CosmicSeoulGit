using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClearBossSound : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundBGM;
    [SerializeField] private AudioSource _bossBGM;
    [SerializeField] private float _fadeDuration = 2f;

    public void ClearBoss(){
       SoundSet();
    }
    
    private void SoundSet()
    {
        _bossBGM.DOFade(0f, _fadeDuration).OnComplete(() => {
            _backgroundBGM.time = 0f;
            _backgroundBGM.DOFade(1f, _fadeDuration);
        });
    }
}
