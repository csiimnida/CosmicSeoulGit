using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TutorialTextSO _tutorialText;
    private TextMeshProUGUI _text;

    private void Awake(){
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
}
