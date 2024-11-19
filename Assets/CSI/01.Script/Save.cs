using EasySave.Json;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    

    public PlayerDataSO _playerDataSo;
    private StartSeting _startSeting;
    private class StartSeting
    {
        public float Damage;
        public float Hp;
        public float MoveSpeed;
        public float JumpPower;
        public float Attack_Speed;
        public StartSeting(PlayerDataSO _playerDataSo)
        {
            Hp = _playerDataSo.Hp;
            Damage = _playerDataSo.Damage;
            MoveSpeed = _playerDataSo.MoveSpeed;
            JumpPower = _playerDataSo.JumpPower;
            Attack_Speed = _playerDataSo.SwordAttackTime;
        }
    }

    
    private void Start()
    {
        _playerDataSo = GameManager.Instance.Player.PlayerData;
        _startSeting = new StartSeting(_playerDataSo);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            TrySave();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
    }
    
    private void TrySave()
    {
        Datas data = new Datas();
        data._saveNum = 1;
        data._playerPowerRare.heavy_weight.Count = 3;
        data._playerPowerNomal.rapid_movement.Count = 5;
        data._screen_name = SceneManager.GetActiveScene().name;//SceneManager.GetActiveScene().name;
        EasyToJson.ToJson<Datas>(data,"SaveData",true);
        
    }

    public void LoadButtn()
    {
        LoadData();
    }

    private void LoadData()
    {
        Datas _saveData;
        _saveData = EasyToJson.FromJson<Datas>("SaveData");
        print("불러오기 성공");
        PlayerStat(_saveData);
        SceneManager.LoadScene(_saveData._screen_name);
        print(Application.dataPath);

    }
    
    public void PlayerStat(Datas _saveData)
    {
        SetNomal(_saveData);
        SetRara(_saveData);
        SetUnique(_saveData);
    }

    private void SetUnique(Datas _saveData)
    {
        SetStat(_saveData._playerPowerUnique.Warrior_Protection);
        SetStat(_saveData._playerPowerUnique.sharpshooter);
    }
    private void SetRara(Datas _saveData)
    {
        SetStat(_saveData._playerPowerRare.Berserker);
        SetStat(_saveData._playerPowerRare.absolute_defense);
        SetStat(_saveData._playerPowerRare.heavy_weight);
        SetStat(_saveData._playerPowerRare.speed_ster);
    }
    private void SetNomal(Datas _saveData)
    {
        SetStat(_saveData._playerPowerNomal.strong_strength);
        SetStat(_saveData._playerPowerNomal.full_of_vitality);
        SetStat(_saveData._playerPowerNomal.rapid_movement);
        SetStat(_saveData._playerPowerNomal.nimble_legs);
    }

    private void SetStat(Stats stat)
    {
        if(stat.Count == 0) return;
        print($"{stat}가 {stat.Count}개 적용");
        for (int i = 0; i < stat.Count; i++)
        {
            _playerDataSo.Damage += getpursent(_startSeting.Damage,stat.Attack_Power);
            _playerDataSo.Hp += getpursent(_startSeting.Hp, stat.Health);
            _playerDataSo.SwordAttackTime -= getpursent(_startSeting.Attack_Speed, stat.Attack_Speed);
            _playerDataSo.MoveSpeed += getpursent(_startSeting.MoveSpeed, stat.Move_Speed);
        }
    }
    private float getpursent(float StartSetting,float persent)
    {
        return StartSetting * persent/ 100;
    }
    
    /*현재 스테이지 및 맵에 배치된 남아있는 적들
현재 위치
플레이어 현재 체력
플레이어 능력치

플레이어 선택 증강*/
}
