using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckLevelUp : MonoBehaviour
{
    [SerializeField] private int _expDemand = 100;
    [SerializeField] private int _increaseRate;
    private Player _player;
    public UnityEvent<int> OnLevelUp;


    private void Start()
    {
        _player = GameManager.Instance.Player;
    }

    public void CheckLevelUpMethod(int nowExp){
        if (nowExp >= _expDemand)
        {
            _expDemand += _increaseRate;
            _player.MaxExp = _expDemand;
            OnLevelUp?.Invoke(_expDemand);
            Debug.Log("레벨업");
        }
    }

    public void ChangeMaxExp(int MaxExp)
    {
        _expDemand = MaxExp;
    }
}
