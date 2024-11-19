using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackSkillCooltime : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    
    [SerializeField] private Image _QSkill;
    [SerializeField] private Image _ESkill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _QSkill.fillAmount = playerData.CurrentSkill1Time/playerData.Skill1Cooltime;
        _ESkill.fillAmount = playerData.CurrentSkill2Time / playerData.Skill2Cooltime;
    }
}
