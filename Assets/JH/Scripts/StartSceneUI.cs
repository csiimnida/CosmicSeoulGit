using System;
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

    
    [SerializeField] private SoundManager soundManager;


    private void Awake()
    {
        SetCreditUI = transform.GetChild(4).gameObject; 

    }

    void Start()
    {
       
        goToSceneButton.onClick.AddListener(GoToTargetScene);
        goToSceneButton.onClick.AddListener(PlayButtonClickSound);
        activatePanelButton.onClick.AddListener(ActivatePanel);
        activatePanelButton.onClick.AddListener(PlayButtonClickSound);
        //deactivatePanelButton.onClick.AddListener(DeactivatePanel); 
        //deactivatePanelButton.onClick.AddListener(PlayButtonClickSound); 
        //quitGameButton.onClick.AddListener(QuitGame);
        quitGameButton.onClick.AddListener(PlayButtonClickSound);

        if (CreditPanel != null)
        {
            CreditPanel.gameObject.SetActive(false);
        }
        if (panel != null)
            panel.SetActive(false);
    }

    private void GoToTargetScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("이동할 씬 이름이 설정되지 않았습니다.");
        }
    }

    private void ActivatePanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
        else
        {
        }
    }

    

    private void QuitGame()
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