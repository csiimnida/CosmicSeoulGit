using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TTlalTextManager : MonoBehaviour
{
    [SerializeField]private TextMeshPro[] textMeshs;
    
    private void Start()
    {
        Change(LanguageManager.Instance.language);
        LanguageManager.Instance.OnLanguageChanged += Change;
    }

    private void Change(_languageType language)
    {
        print(language);
        if (language == _languageType.Eng)
        {
            textMeshs[0].text = "Press <color=yellow>A/D</color> to move left/right.";
            textMeshs[1].text = "Press <color=yellow>SPACE</color> to jump.";
            textMeshs[2].text = "Use <color=yellow>Basic Attack (Left Click)</color> and\n<color=yellow>Skills (Q, E)</color> to defeat enemies.";
            textMeshs[3].text = "Use <color=yellow>Rolling (Shift)</color> and <color=yellow>Parry (Right Click)</color> to dodge.";
            textMeshs[4].text = "Killing enemies will <color=green>restore a small amount of health</color>.";
                
        }else if (language == _languageType.Ko)
        {
            textMeshs[0].text = "<color=yellow>A/D</color>를 눌러 좌/우이동";
            textMeshs[1].text = "<color=yellow>SPACE</color>를 눌러 점프";
            textMeshs[2].text = "<color=yellow>평타(좌클릭)</color> & <color=yellow>스킬(Q,E)</color>을 사용해서\n적을 죽이세요";
            textMeshs[3].text = "<color=yellow>구르기(shift)</color>와 <color=yellow>패링(우클릭)</color>을\n사용하여 회피하세요";
            textMeshs[4].text = "적을 죽이면 <color=green>체력을 소량 회복합니다</color>";
        }
    }
}
