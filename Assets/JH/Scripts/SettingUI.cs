using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingUI : MonoBehaviour
{   
    [SerializeField] private SoundManager soundManager;

    private GameObject SetUI;
    private void Awake()
    {
        SetUI = transform.GetChild(0).gameObject;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (SetUI.active)
            {
                SetUI.SetActive(false);
                Time.timeScale = 1; 

            }
            else
            {
                SetUI.SetActive(true);
                Time.timeScale = 0;

            }
        }
    }
    public void DestroyUI()
    {
        
        
            SetUI.SetActive(false);
            soundManager.PlaySound("Bt_Click");
            Time.timeScale = 1;
        
        

    }
}
