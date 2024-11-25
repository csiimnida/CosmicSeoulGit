using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoSingleton<TimerManager>{
    [SerializeField] private Player _player;



    private void Update(){
        if (_player == null)
        {
            try
            {
                _player = GameManager.Instance.Player;

            }
            finally
            {
                
                
            }
            return;
        }
        _player.PlayerData.CurrentRoolTime += Time.deltaTime;
        _player.PlayerData.CurrentBlockTime += Time.deltaTime;
        _player.PlayerData.CurrentSkill1Time += Time.deltaTime;
        _player.PlayerData.CurrentSkill2Time += Time.deltaTime;

        if (_player.PlayerData.CurrentRoolTime >= _player.PlayerData.RollCooltime)
            _player.PlayerData.CanRool = true;
        if (_player.PlayerData.CurrentBlockTime >= _player.PlayerData.BlockCooltime)
            _player.PlayerData.CanBlock = true;
        if (_player.PlayerData.CurrentSkill1Time >= _player.PlayerData.Skill1Cooltime)
            _player.PlayerData.CanSkill1 = true;
        if (_player.PlayerData.CurrentSkill2Time >= _player.PlayerData.Skill2Cooltime)
            _player.PlayerData.CanSkill2 = true;
    }
}
