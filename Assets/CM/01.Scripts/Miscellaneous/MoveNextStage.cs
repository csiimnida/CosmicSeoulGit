using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MoveNextStage : MonoBehaviour{
    [SerializeField] private Image _blackPanel;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private string _nextSceneName;

    [SerializeField] public AudioSource _backgroundBgm;

    private bool _isClear;
    private bool _isCollision = false;

    private void Start(){
        _isClear = SceneManager.GetActiveScene().name == "Tutorial" ? true : false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player"))
            if (_isClear && !_isCollision)
                MoveNextStageMethod();
    }

    private void MoveNextStageMethod(){
        _isCollision = true;
        StartCoroutine(FadeIn());
        StartCoroutine(SoundDown());
    }

    private IEnumerator FadeIn(){
        _blackPanel.DOFade(2f, _fadeDuration);
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
        //Save.Instance.TrySave();
        SceneManager.LoadScene(_nextSceneName);
    }

    private IEnumerator SoundDown(){
        for (int i = 0; i < 100; i++)
        {
            _backgroundBgm.volume -= 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
    }

    public void ClearStage(){
        _isClear = true;
    }
}