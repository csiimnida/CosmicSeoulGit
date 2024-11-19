using EasySave.Json;
using UnityEngine;
using System;

public class Save : MonoBehaviour
{
    

    private Datas _saveData;

    private void TrySave()
    {
        Datas data = new Datas();
        data._saveNum = 1;
        _saveData = EasyToJson.FromJson<Datas>("SaveData");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TrySave();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        if (EasyToJson.IsExistJson("SaveData"))
        {
            EasyToJson.ToJson<Datas>(_saveData,"SaveData",true);
        }

    }
    
    /*현재 스테이지 및 맵에 배치된 남아있는 적들
현재 위치
플레이어 현재 체력
플레이어 능력치
플레이어 선택 증강*/
}
