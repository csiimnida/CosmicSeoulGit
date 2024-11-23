using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardCheacker : MonoBehaviour , IPointerEnterHandler, IPointerDownHandler , IPointerExitHandler
{
    private bool hasPointerEntered = false; // 플래그 변수
    private bool hasPointer = false;
    private Vector2 currentSize = Vector2.zero;
    private RectTransform rect;
    private Tween scaleTween;
    public Action _OnClick;
    private void Awake()
    {rect =transform.GetChild(0).GetComponent<RectTransform>();
        currentSize = rect.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!hasPointer)
        { hasPointer = true;
          scaleTween?.Kill();
          scaleTween = rect.DOScale(currentSize * 1.2f, 0.1f).OnComplete(() =>
            { hasPointer = true;});
        }
    }
 public void OnPointerExit(PointerEventData eventData)
    {
        if (hasPointer)
        { hasPointer = false;
            scaleTween?.Kill();
            scaleTween = rect.DOScale(currentSize, 0.1f).OnComplete(() =>
            { hasPointer = false;});
        }
    }
        public void OnPointerDown(PointerEventData eventData)
    {   if (!hasPointerEntered)
        { hasPointerEntered = true; // 플래그 설정
         CardManager.Instance.FrontSprite(this.gameObject.GetComponent<CardCheacker>());
            _OnClick?.Invoke();
        }
    }
}
