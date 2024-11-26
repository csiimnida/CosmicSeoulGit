using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _moveTime = 1f;
    public UnityEvent OnEnd;
    private float _curTime;
    private void Start(){
        gameObject.transform.DOMoveX(_targetPosition.position.x, _moveTime).SetEase(Ease.Linear);
    }

    private void Update(){
        _curTime += Time.deltaTime;
        if (_curTime >= _moveTime - 10f)
        {
            OnEnd?.Invoke();
        }
    }
}
