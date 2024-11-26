using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBossSound : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundBGM;
    [SerializeField] private AudioSource _bossBGM;
    [SerializeField] private float _fadeDuration = 3f;

    public void ClearBoss(){
        StartCoroutine(BossSoundUp());
    }
    
    private IEnumerator BossSoundUp(){
        for (int i = 0; i < 100; i++)
        {
            _backgroundBGM.volume += 0.01f;
            _bossBGM.volume -= 0.01f;
            yield return new WaitForSeconds(0.02f);
        }

        _backgroundBGM.volume = 1f;
        _bossBGM.volume = 0f;
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
    }
}
