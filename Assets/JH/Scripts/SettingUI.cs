using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SettingUI : MonoBehaviour
{   
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject MainMenuButton;
    private GameObject SetUI;
    private void Awake()
    {
        SetUI = transform.GetChild(0).gameObject;
        MainMenuButton.SetActive(false);
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (SetUI.activeSelf)
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

    public void ReturnMainMenu()
    {
       Application.Quit(); 
    }
}
