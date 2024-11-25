using System;
using DG.Tweening;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _moveTime = 1f;
    private void Start(){
        gameObject.transform.DOMoveX(_targetPosition.position.x, _moveTime).SetEase(Ease.Linear);
    }
}
