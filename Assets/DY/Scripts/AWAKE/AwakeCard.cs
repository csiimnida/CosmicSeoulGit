using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeCard : MonoBehaviour
{
    public List<AwakeSO> _awake;
    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private CardEventCheacker _eventCheacker;
 
    Image _image;
   [SerializeField] Text _text;
   [SerializeField] Text _Attacktext;
   [SerializeField] Text _Healthtext;
   [SerializeField] Text _AttackSpdtext;
   [SerializeField] Text _WalkSpdtext;
   public int rand = 0;
    private void Awake()
    {
        _image = GetComponent<Image>();
        RandomAwake();
    }

    private void Start()
    {
        _eventCheacker._Click += PlayerStat;
    }
    public void RandomAwake()
    { rand = Random.Range(0,_awake.Count);
        _image.sprite = _awake[rand].sprites;
        _text.text = _awake[rand].Name;
        _Attacktext.text ="공격력: "+ _awake[rand].Attack.ToString() + "%";
        _Healthtext.text = "체력: "+_awake[rand].Defende.ToString() + "%";
        _AttackSpdtext.text = "공격속도: "+_awake[rand].AttackAirSpeed.ToString() + "%";
        _WalkSpdtext.text = "이동속도: "+_awake[rand].MoveSpeed.ToString() + "%";
    
    }

    public void PlayerStat()
    {
        _playerData.Damage += _awake[rand].Attack * _awake[rand].Attack/100;
        _playerData.Hp += _awake[rand].Defende  *_awake[rand].Defende / 100;
        _playerData.SwordAttackTime += _awake[rand].AttackAirSpeed * _awake[rand].AttackAirSpeed / 100;
        _playerData.MoveSpeed += _awake[rand].MoveSpeed * _awake[rand].MoveSpeed / 100;
    }
}
