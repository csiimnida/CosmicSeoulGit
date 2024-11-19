using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class Card : CardEventCheacker
{/// <summary>
/// s e x
/// </summary>
    public int index = 0;
    public Vector3 _currentVectorScale;
   public CardDataSO _CardDataSO;
    public Image _Image;

   
    private void Start()
    { _currentVectorScale = _rect.localScale;
        _rect.DORotate(new Vector3(0, 0f, 0), 0.5f, RotateMode.Fast).OnComplete(() => _rect.DOKill()); BackSprite();
        _Image = _Image.gameObject.GetComponent<Image>();  
      foreach (Transform t in _rect.transform)
        { t.gameObject.SetActive(false);}}
    private void Update() { if (_rect == null) return; }
    #region 오버레이 숨기기및 마우스 포인터가 올라갔을때 실행되는 경우 코루틴 주석 풀면됨
    //IEnumerator HideOverlayCorutin()
    //    {HideOverlay();
    //        yield return null;}
    // IEnumerator ShowOverlayCorutin()
    //    {ShowOverlay();
    //        yield return null;}
    //public void HideOverlay()
    //{foreach (Transform t in rect.transform)
    //        { t.gameObject.SetActive(false); }} 
    #endregion
 public void ShowOverlay()
    {foreach (Transform t in _rect.transform){ t.gameObject.SetActive(true); } _isPressed = true;}
public void BackSprite()
    {_Image.sprite = _CardDataSO._Backsprite;}
 public void FrontSprite()
    { _Image.sprite = _CardDataSO._Frontsprite; Camera.main.DOShakePosition(0.5f, 1f, 5, 30f); }
}




