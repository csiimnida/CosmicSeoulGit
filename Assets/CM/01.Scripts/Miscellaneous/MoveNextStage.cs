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

    private BoxCollider2D _boxCollider;

    private bool _isClear;
    private bool _isCollision = false;

    private void Awake(){
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start(){
        _isClear = SceneManager.GetActiveScene().name == "Tutorial" ? true : false;
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            _boxCollider.isTrigger = true;
            return;
        }
        _boxCollider.isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player"))
            if (_isClear && !_isCollision)
                MoveNextStageMethod();
    }

    public void EndingSceneEnd(){
        StartCoroutine(FadeInEnding());
        StartCoroutine(SoundDown());
        Application.Quit();
    }

    private void MoveNextStageMethod(){
        _isCollision = true;
        StartCoroutine(FadeIn());
        StartCoroutine(SoundDown());
    }

    private IEnumerator FadeIn(){
        _blackPanel.DOFade(2f, _fadeDuration);
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
        Datas d = new Datas();
        Save.Instance.TrySave<Datas>(d,_nextSceneName);
        SceneManager.LoadScene(_nextSceneName);
    }
    private IEnumerator FadeInEnding(){
        _blackPanel.DOFade(2f, _fadeDuration);
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
        Application.Quit();
    }

    private IEnumerator SoundDown(){
        for (int i = 0; i < 100; i++)
        {
            if (AudioListener.volume < 0)
            {
                AudioListener.volume = 0;
                break;
            }
            AudioListener.volume -= 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
    }

    public void ClearStage(){
        _isClear = true;
        _boxCollider.isTrigger = true;
    }
}