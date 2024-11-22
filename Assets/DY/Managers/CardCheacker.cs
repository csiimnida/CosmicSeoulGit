using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardCheacker : MonoBehaviour , IPointerEnterHandler, IPointerDownHandler , IPointerExitHandler
{
    private bool hasPointerEntered = false; // �÷��� ����

    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasPointerEntered = false; // �÷��� �ʱ�ȭ
        Debug.Log("Pointer exited!");
        CardManager.Instance.BackSprite();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!hasPointerEntered)
        {
            hasPointerEntered = true; // �÷��� ����
            Debug.Log("Pointer entered for the first time!");
            CardManager.Instance.FrontSprite();
        }
    }



}
