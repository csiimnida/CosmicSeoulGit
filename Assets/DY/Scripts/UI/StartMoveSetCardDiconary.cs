using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class StartMoveSetCardDiconary : MonoBehaviour 
{ public List<RectTransform> target;
    public Transform endtarget;
    [SerializeField] List<CardEventCheacker> _CardEventCheacker;
    public float duration = 5f;

private void Awake()
    {

        for (int i = 0; i < target.Count; i++)
        {target[i] = target[i].GetComponent<RectTransform>();
      }}
private void Start()
{for (int i = 0; i < target.Count; i++)
        {
            target[i].DOAnchorPos(new Vector2(target[i].transform.position.x * 100, target[i].transform.position.y), duration);
           
            _CardEventCheacker[i]._Click += EndMoveset;
        }

       


    }

    private void EndMoveset()
    {

        for (int i = 0; i < target.Count; i++)
        {
            target[i].DOAnchorPos(new Vector2(endtarget.position.x * 100, endtarget.position.y * 25f), duration);

        }


    }
}
