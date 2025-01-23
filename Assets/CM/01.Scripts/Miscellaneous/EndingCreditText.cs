using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EndingCreditText : MonoBehaviour{
    private TextMeshProUGUI _text;
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration;

    private void Awake(){
        _text = GetComponent<TextMeshProUGUI>();
    }

    private string enText =
        "<CREDIT>\n\n\n\n장준서 - Team Leader\n\n\n\n이찬민 - Main Developer\n\n\n\n김동영 - Developer, Sub Art & Effects\n\n\n\n송주하 - Planner, Sub Developer & Art\n\n\n\nThank you for playing our game!";
    private string koText =
        "<CREDIT>\n\n\n\n장준서-팀장\n\n\n\n이찬민-메인 개발\n\n\n\n김동영-개발, 서브 아트&이펙트\n\n\n\n송주하-기획, 서브 개발&아트\n\n\n\n\n\n저희 게임을 플레이해주셔서 감사합니다";
    private void Start()
    {
        LanguageManager.Instance.OnLanguageChanged += Change;
        _text.rectTransform.DOMoveY(_target.position.y, _duration).SetEase(Ease.Linear);
    }
    
    private void Change(_languageType language)
    {
        print(language);
        if (language == _languageType.Eng)
        {
            _text.text = enText;

        }else if (language == _languageType.Ko)
        {
            _text.text = koText;
        }
    }
}
