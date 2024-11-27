using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
public class CardCheacker : MonoBehaviour , IPointerEnterHandler, IPointerDownHandler , IPointerExitHandler
{
    private int  count = 0;
    private bool hasPointerEntered = false; // �÷��� ����
    private bool hasPointer = false;
    private Vector2 currentSize = Vector2.zero;
    private RectTransform rect = null;
    private Tween scaleTween = null;
    public Action _OnClick;
    private bool isClick = false;
    private bool isFront;
    private void Awake()
    {rect =transform.GetChild(0).GetComponent<RectTransform>();
        currentSize = rect.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!hasPointer)
        { hasPointer = true;
          scaleTween?.Kill();
            CardManager.Instance.GameobjectGet(transform.GetChild(1).gameObject, true);
        }

    }

     public void OnPointerExit(PointerEventData eventData)
    {
        if (hasPointer)
        { hasPointer = false;
            scaleTween?.Kill();
            CardManager.Instance.GameobjectGet(transform.GetChild(1).gameObject, false);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {   
        
     
     
        CardManager.Instance.FrontSprite(this.gameObject.GetComponent<CardCheacker>());
        _OnClick?.Invoke();
            
        if (isFront)
        { 
            CardManager.Instance.EndCardPolling();
            CardManager.Instance.Enter(gameObject.GetComponent<CardCheacker>());
            isFront = false;
           
        }// �÷��� ����
        isFront = true;
        
    }
}
