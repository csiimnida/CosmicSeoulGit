using System;
using UnityEngine;
using DG.Tweening;

public class CardCrater : MonoBehaviour
{
    [SerializeField]private Transform _card;
    private GameObject[] _clondedObjs;
    [SerializeField]private AwakeSO[] _cardDatas;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCard();
        }
    }

    public void StartCard()
    {
        _clondedObjs = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            _clondedObjs[i] = Instantiate(_card, transform).gameObject;
            LoopMove loopMove = _clondedObjs[i].GetComponentInChildren<LoopMove>();
            //_clondedObjs[i].transform.DOMoveX(i==0?-1.5f:i==2?1.5:0, 0.2f).SetUpdate(true);
            _clondedObjs[i].transform.DOMoveY(3, 0.2f).SetUpdate(true).OnComplete(() =>
            {
                loopMove.Play = true;
            });
        }
    }


}
