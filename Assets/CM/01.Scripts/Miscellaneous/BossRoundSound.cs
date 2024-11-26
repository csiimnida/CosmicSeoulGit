using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoundSound : MonoBehaviour{
    [SerializeField] private AudioSource _backgroundBGM;
    [SerializeField] private AudioSource _bossBGM;
    [SerializeField] private float _fadeDuration = 3f;

    private void OnEnable(){
        StartCoroutine(BossSoundUp());
    }
    
    private IEnumerator BossSoundUp(){
        _bossBGM.gameObject.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            _backgroundBGM.volume -= 0.01f;
            _bossBGM.volume += 0.01f;
            yield return new WaitForSeconds(0.02f);
        }

        _backgroundBGM.volume = 0f;
        _bossBGM.volume = 1f;
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
    }
}
