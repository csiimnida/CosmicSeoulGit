using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPUI : MonoBehaviour
{
    public PlayerDataSO playerData;
    private Player _player;
    public Image healthImage;
    
    public Sprite DeadheartSprite;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.Instance.Player;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        float healthPercentage = (float)_player.NowHP / playerData.Hp;
        
        healthImage.fillAmount = healthPercentage;
        if (_player.NowHP <= 0)
        {
            healthImage.sprite = DeadheartSprite;
            healthImage.fillAmount = 1f;

        }
        
        
    }
}
