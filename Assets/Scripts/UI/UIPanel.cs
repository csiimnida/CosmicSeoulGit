using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIPanel : MonoBehaviour
{
  [SerializeField]List< CardEventCheacker> OnCardEventCheacker;

    private Image _Image;
    public float Endvar;
    public float duration = 1f;
    private void Start()
    {_Image = GetComponent<Image>();
        for (int i = 0; i < OnCardEventCheacker.Count; i++)
        { OnCardEventCheacker[i]._OnFadeOut += UIFadeOut;
            OnCardEventCheacker[i]._OnFadeOutExit += UIFadeOutExit;}
    }
private void UIFadeOut()
    {_Image.DOFade(Endvar, duration);}

    private void UIFadeOutExit()
    {_Image.DOFade(0, duration);}
}
