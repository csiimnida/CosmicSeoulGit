using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CardManager : MonoSingleton<CardManager> 
{
    [SerializeField] private List<GameObject> _well;
    [SerializeField] private GameObject _CardPrefab;
    private Transform _target;
 private Image[] _image;
    public float duration = 0.2f;
    public float range = 10f;
  [SerializeField] private  CardSO Sprite;
    Transform[] _pivot;
    private void Awake()
    {
        _well = new List<GameObject>(2);
      _pivot = new Transform[3];
        _image = new Image[3];
        _target = transform.GetChild(0);
        for (int i = 0; i <= 2; i++)
        {
            _well.Add(Instantiate(_CardPrefab, transform));
            _well[i].AddComponent<CardCheacker>();
        }
           
        
        for (int i = 0; i < 3; i++)
        {
           
            _well[i].GetComponent<Canvas>().worldCamera = Camera.main;
            _well[i] = _well[i].transform.GetChild(0).gameObject;
            _image[i] = _well[i].transform.GetChild(0).GetChild(0).GetComponent<Image>();
        
        }
    }
     private void Start()
    {
        StartCardPolling();
     
    }
    public void StartCardPolling()
    {
        for (int i = 0; i < 3; i++)
        _well[i].transform.DOMove(new Vector3(_well[i].transform.position.x* i * range,  _target.transform.position.y, _well[i].transform.position.z), duration);
      _well[1].transform.DOMove(new Vector3(_well[1].transform.position.x * 1 * -100, _target.transform.position.y, _well[1].transform.position.z), duration);
        BackSprite();
    }
    public void BackSprite()
    {
       for (int i = 0; i < 3; i++)
        {
          _well[i].transform.DOScaleX(-0.18f, duration);
            _image[i].gameObject.SetActive(false);
            _well[i].GetComponent<Image>().sprite = Sprite.BackSprite;
       
        }
      }
    public void FrontSprite()
    {
        for (int i = 0; i < 3; i++)
        {
            _well[i].transform.DOScaleX(0.18f, duration);
            _image[i].gameObject.SetActive(true);
            _well[i].GetComponent<Image>().sprite = Sprite.BackSprite;

        }
    }

  
}
