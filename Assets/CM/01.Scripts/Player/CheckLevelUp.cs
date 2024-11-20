using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckLevelUp : MonoBehaviour{
    [SerializeField] private int _expDemand = 100;
    [SerializeField] private int _increaseRate;
    public UnityEvent OnLevelUp;

    public void CheckLevelUpMethod(int nowExp){
        if (nowExp >= _expDemand)
        {
            OnLevelUp?.Invoke();
            _expDemand += _increaseRate;
            Debug.Log("레벨업");
        }
    }
}
