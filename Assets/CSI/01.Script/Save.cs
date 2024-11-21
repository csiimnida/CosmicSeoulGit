using EasySave.Json;
using UnityEngine;
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
        data._screen_name = SceneManager.GetActiveScene().name;//SceneManager.GetActiveScene().name;
        EasyToJson.ToJson<Datas>(data,"SaveData",false);
        
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
        SetPlayerStat(_saveData);
        SceneManager.LoadScene(_saveData._screen_name);
        print(Application.dataPath);

    }

    private void SetPlayerStat(Datas saveData)
    {
        _playerDataSo.Damage = saveData.Damage;
        _playerDataSo.MoveSpeed = saveData.MoveSpeed;
        _playerDataSo.RollPower = saveData.RollPower;
        _playerDataSo.Hp = saveData.Health;
        _playerDataSo.SwordAttackTime = saveData.Attack_Speed;
    }


    /*현재 스테이지 및 맵에 배치된 남아있는 적들
현재 위치
플레이어 현재 체력
플레이어 능력치

플레이어 선택 증강*/
}
