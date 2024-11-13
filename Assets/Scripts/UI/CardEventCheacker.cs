using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CardEventCheacker : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    protected RectTransform _rect;
    private bool _isRotated = false;
    protected float _Duration = 0.5f;
    protected bool _isPressed;
    public bool isFront;
    public Action _OnFadeOut, _OnFadeOutExit;
    Card card;
    [SerializeField] Canvas _canvas;
    private void Awake()
    {
        card = GetComponent<Card>();
        _canvas.overrideSorting = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isRotated) _rect.DORotate(new Vector3(0, 0f, 0), 0.5f, RotateMode.Fast)
      .OnComplete(() => _isRotated = true);
          card.FrontSprite();
        
        #region 예외처리
        try
        {
            _rect.DORotate(new Vector3(0, 0f, 0), 0.5f, RotateMode.Fast)
      .OnComplete(() => _isRotated = false);
        }
        catch (System.Exception ex)
        { Debug.LogError("아직 돌아가는중입니다."); }

        #endregion
        if (!_isPressed) card.ShowOverlay();
        #region 마우스포인터가 올라가있었을때 보이고 싶게 하고싶으면 코루틴 주석 풀기
        //StartCoroutine(ShowOverlayCorutin());
        #endregion
    }
    public void OnPointerExit(PointerEventData eventData)
    { this._canvas.sortingOrder = 0; isFront = false; _OnFadeOutExit?.Invoke(); CameraScaleExit(); Scale(1.0f); _isRotated = true; }
    public void OnPointerEnter(PointerEventData eventData)
    { this._canvas.sortingOrder = 2; CameraScale(); isFront = true; Scale(1.2f); _OnFadeOut?.Invoke(); }
    public void Scale(float mutiply)
    {
        _rect.DOScale(new Vector3(card._currentVectorScale.x * mutiply, card._currentVectorScale.y * mutiply, card._currentVectorScale.z), _Duration);
    }

    private void CameraScale()
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 25f, _Duration);
    }

    private void CameraScaleExit()
    {
        Camera.main.DOOrthoSize(5, 0.5f);
        Camera.main.DOShakePosition(0.2f,3,10,90,true); 
    }


}
