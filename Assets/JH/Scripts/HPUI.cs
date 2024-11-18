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
        if (healthSprites == null || healthSprites.Count != 10)
        {
            Debug.LogError("Health sprites must contain exactly 10 sprites (10% increments)!");
            return;
        }
        if (playerData == null)
        {
            Debug.LogError("PlayerData is not assigned!");
            return;
        }
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        //int spriteIndex = Mathf.Clamp((int)((float)_player / playerData.maxHealth * 10) - 1, 0, 9);
        if (healthImage != null)
        {
            
        }
    }
}
