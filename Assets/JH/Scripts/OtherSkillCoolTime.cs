using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherSkillCoolTime : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    
    [SerializeField] private Image _block;
    [SerializeField] private Image _roll;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _block.fillAmount = playerData.CurrentBlockTime/playerData.BlockCooltime;
        _roll.fillAmount = playerData.CurrentRoolTime/playerData.RollCooltime-0.15f;
    }
}
