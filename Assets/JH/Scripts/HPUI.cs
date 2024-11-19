using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPUI : MonoBehaviour
{
    public PlayerDataSO playerData;
    public Player _player;
    public Image healthImage;
    public List<Sprite> healthSprites;
    public Sprite DeadheartSprite;
    // Start is called before the first frame update
    void Start()
    {
        
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
        int spriteIndex = Mathf.Clamp(Mathf.CeilToInt(healthPercentage * 10) - 1, 0, 9);
        if (_player.NowHP <= 0)
        {
            healthImage.sprite = DeadheartSprite;

        }
        else if (healthImage != null&&_player.NowHP!=0)
        {
            healthImage.sprite = healthSprites[spriteIndex];
            
        }
        
    }
}
