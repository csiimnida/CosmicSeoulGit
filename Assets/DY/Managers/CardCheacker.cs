using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardCheacker : MonoBehaviour , IPointerEnterHandler, IPointerDownHandler , IPointerExitHandler
{
    private bool hasPointerEntered = false; // 플래그 변수

    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasPointerEntered = false; // 플래그 초기화
        Debug.Log("Pointer exited!");
        CardManager.Instance.BackSprite();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!hasPointerEntered)
        {
            hasPointerEntered = true; // 플래그 설정
            Debug.Log("Pointer entered for the first time!");
            CardManager.Instance.FrontSprite();
        }
    }



}
