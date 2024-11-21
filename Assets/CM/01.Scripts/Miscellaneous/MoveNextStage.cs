using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MoveNextStage : MonoBehaviour
{
    [SerializeField] private Image _blackPanel;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private string _nextSceneName;
    
    private bool _isClear;

    private void Start(){
        _isClear = SceneManager.GetActiveScene().name == "Tutorial" ? true : false;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player"))
            if(_isClear)
                MoveNextStageMethod();
                
    }

    private void MoveNextStageMethod(){
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn(){
        _blackPanel.DOFade(2f, _fadeDuration);
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
        SceneManager.LoadScene(_nextSceneName);
    }

    public void ClearStage(){
        _isClear = true;
    }
}
