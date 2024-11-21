using EasySave.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoSingleton<Save>
{

    private PlayerDataSO _playerDataSo;
    private Player _player;
    private StartSeting _startSeting;
    private CheckLevelUp _checkLevelUp;
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
        _player = GameManager.Instance.Player;
        _checkLevelUp = _player.GetComponent<CheckLevelUp>();
        _playerDataSo = _player.PlayerData;
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
        data.Damage = _playerDataSo.Damage;
        data.MoveSpeed = _playerDataSo.MoveSpeed;
        data.RollPower  = _playerDataSo.RollPower;
        data.Health = _playerDataSo.Hp;
        data.Attack_Speed = _playerDataSo.SwordAttackTime;
        data.MaxExp = _player.MaxExp;
        data.Exp = _player.Exp;
        data._screen_name = SceneManager.GetActiveScene().name;//SceneManager.GetActiveScene().name;
        EasyToJson.ToJson<Datas>(data,"SaveData",false);
        
    }

    public void NewGame()
    {
        Datas data = new Datas();
        EasyToJson.ToJson<Datas>(data,"SaveData",false);
        LoadData();
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
        SceneManager.LoadScene(_saveData._screen_name);
        SetPlayerStat(_saveData);

    }

    private void SetPlayerStat(Datas saveData)
    {
        _playerDataSo.Damage = saveData.Damage;
        _playerDataSo.MoveSpeed = saveData.MoveSpeed;
        _playerDataSo.RollPower = saveData.RollPower;
        _playerDataSo.Hp = saveData.Health;
        _playerDataSo.SwordAttackTime = saveData.Attack_Speed;
        _checkLevelUp.ChangeMaxExp(saveData.MaxExp);
        _player.Exp = saveData.Exp;
        
    }


    /*현재 스테이지 및 맵에 배치된 남아있는 적들
현재 위치
플레이어 현재 체력
플레이어 능력치

플레이어 선택 증강*/
}
