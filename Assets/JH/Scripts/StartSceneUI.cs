using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUI : MonoBehaviour
{
    
    [SerializeField] private string targetSceneName;

    
    [SerializeField] private GameObject panel;

    
    [SerializeField] private Button goToSceneButton;
    [SerializeField] private Button activatePanelButton;
    [SerializeField] private Button deactivatePanelButton; 
    [SerializeField] private Button quitGameButton;
    [SerializeField] private Button OnCreditButton;
    [SerializeField] private Image CreditPanel;
    
    private GameObject SetCreditUI;
    public GameObject LoadingScreen;

    
    [SerializeField] private SoundManager soundManager;
    

    private void Awake()
    {
        SetCreditUI = transform.GetChild(4).gameObject; 
        

    }
    public TextMeshProUGUI _noContinuetext;
    public TextMeshProUGUI _Continuetext;
    void Start()
    {
       
        goToSceneButton.onClick.AddListener(GoToTargetScene);
        activatePanelButton.onClick.AddListener(ActivatePanel);
        quitGameButton.onClick.AddListener(PlayButtonClickSound);
        LanguageManager.Instance.OnLanguageChanged += (language) =>
        {
            print(language);
            try
            {
                if (language == _languageType.Eng)
                {
                    goToSceneButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
                    activatePanelButton.GetComponentInChildren<TextMeshProUGUI>().text = "Settings";
                    quitGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Quit";
                
                }else if (language == _languageType.Ko)
                {
                    goToSceneButton.GetComponentInChildren<TextMeshProUGUI>().text = "시작하기";
                    activatePanelButton.GetComponentInChildren<TextMeshProUGUI>().text = "설정";
                    quitGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "나가기";
                
                }
            }
            catch
            {
                
            }
        };
        LanguageManager.Instance.OnLanguageChanged += (lan) =>
        {
            if (lan == _languageType.Ko)
            {
                _noContinuetext.text = "처음부터";
                _Continuetext.text = "이어하기";
            }else if (lan == _languageType.Eng)
            {
                _noContinuetext.text = "From the beginning.";
                _Continuetext.text = "Continue";
            }
        };
        if (CreditPanel != null)
        {
            CreditPanel.gameObject.SetActive(false);
        }
        if (panel != null)
            panel.SetActive(false);
    }

    private void GoToTargetScene()
    {
        PlayButtonClickSound();
        LoadingScreen.SetActive(true);
        
        
    }

    private void ActivatePanel()
    {
        PlayButtonClickSound();
        if (panel != null)
        {
            panel.SetActive(true);
        }
        else
        {
        }
    }

    

    public void QuitGame()
    {
        Application.Quit(); 
    }
    
    private void PlayButtonClickSound()
    {
        soundManager.PlaySound("Bt_Click");
        
    }
    public void DestroyUI()
    {
        
        OnCreditButton.gameObject.SetActive(true);
        SetCreditUI.SetActive(false);
        soundManager.PlaySound("Bt_Click");
        Time.timeScale = 1;
        
        

    }

    public void OnCreditUI()
    {
        OnCreditButton.gameObject.SetActive(false);

        SetCreditUI.SetActive(true);
        soundManager.PlaySound("Bt_Click");
        
    }
}