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

    
    [SerializeField] private SoundManager soundManager;
    


    void Start()
    {
       
        goToSceneButton.onClick.AddListener(GoToTargetScene);
        goToSceneButton.onClick.AddListener(PlayButtonClickSound);
        activatePanelButton.onClick.AddListener(ActivatePanel);
        activatePanelButton.onClick.AddListener(PlayButtonClickSound);
        deactivatePanelButton.onClick.AddListener(DeactivatePanel); 
        deactivatePanelButton.onClick.AddListener(PlayButtonClickSound); 
        //quitGameButton.onClick.AddListener(QuitGame);
        quitGameButton.onClick.AddListener(PlayButtonClickSound);

        
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

    private void DeactivatePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("�г��� �������� �ʾҽ��ϴ�.");
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
}