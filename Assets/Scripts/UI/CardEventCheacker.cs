using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class CardEventCheacker : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    protected RectTransform _rect;
    private bool _isRotated = false;
    protected float _Duration = 0.5f;
    protected bool _isPressed;
    public bool isFront;
    public Action _OnFadeOut, _OnFadeOutExit, _OnClick;
    private bool isText;
    Card card;
    [SerializeField] Canvas _canvas;
    [SerializeField] private TypingManager _typingManager;
    [SerializeField] private List<Text> _textList;
 
    private void Awake()
    {
    
        card = GetComponent<Card>();
        _canvas.overrideSorting = true; 
        camREset();
        isText = false;
    }

    private void Start()
    {
        for (int i = 0; i < _textList.Count; i++)
        _textList[i].gameObject.SetActive(false);
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _OnClick?.Invoke();
        if (!_isRotated) _rect.DORotate(new Vector3(0, -180f, 0), 0.5f)
      .OnComplete(() => _isRotated = true  );
          card.FrontSprite();
        for (int i = 0; i < _textList.Count; i++)
        {
            _textList[i].gameObject.SetActive(false);
        }
      
       
        #region 예외처리
      //  try
      //  {
      //      _rect.DORotate(new Vector3(0, 0f, 0), 0.5f, RotateMode.Fast)
      //.OnComplete(() => _isRotated = false);
      //  }
      //  catch (System.Exception ex)
      //  { Debug.LogError("아직 돌아가는중입니다."); }

        #endregion
        if (!_isPressed) card.ShowOverlay();
        #region 마우스포인터가 올라가있었을때 보이고 싶게 하고싶으면 코루틴 주석 풀기
        //StartCoroutine(ShowOverlayCorutin());
        #endregion
    }
    public void OnPointerExit(PointerEventData eventData)
    { this._canvas.sortingOrder = 0; isFront = false; _OnFadeOutExit?.Invoke(); CameraScaleExit(); Scale(1.0f); _isRotated = true; for (int i = 0; i < _textList.Count; i++)
            _textList[i].gameObject.SetActive(false); ;
        _typingManager._TypingStop();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        this._canvas.sortingOrder = 2; CameraScale(); isFront = true; Scale(1.2f); _OnFadeOut?.Invoke(); if (!isText) for (int i = 0; i < _textList.Count; i++)
            _textList[i].gameObject.SetActive(true); ;
        _typingManager._Typing();
    }
    public void Scale(float mutiply)
    {
        _rect.DOScale(new Vector3(card._currentVectorScale.x * mutiply, card._currentVectorScale.y * mutiply, card._currentVectorScale.z), _Duration);
    }

    private void CameraScale()
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 25f, 1f);
    }

    private void CameraScaleExit()
    {
        Camera.main.DOOrthoSize(5, 0.5f);
        Camera.main.DOShakePosition(0.2f, 1, 3, 25, true).OnComplete(() => camREset());
    
    }

    private void camREset()
    {
        Camera.main.transform.position = new Vector3(0, 0, 0);
    }

}
