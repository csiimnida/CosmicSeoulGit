using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class StartMoveSetCardDiconary : MonoBehaviour 
{ public List<RectTransform> target;
    public float duration = 5f;
private void Awake()
    { for (int i = 0; i < target.Count; i++)
      {
       target[i] = target[i].GetComponent<RectTransform>();
      }}
private void Start()
{for (int i = 0; i < target.Count; i++)
        {target[i].DOAnchorPos(new Vector2(target[i].transform.position.x * 100, target[i].transform.position.y), duration); }}
}
