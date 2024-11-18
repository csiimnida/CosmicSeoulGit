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
    // Start is called before the first frame update
    void Start()
    {
        
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        int spriteIndex = Mathf.Clamp((int)((float)_player.NowHP / playerData.Hp * 10) - 1, 0, 9);
        if (healthImage != null&&_player.NowHP!=0)
        {
            healthImage.sprite = healthSprites[spriteIndex];
            
        }
        else if (_player.NowHP <= 0)
        {
            
        }
        
    }
}
