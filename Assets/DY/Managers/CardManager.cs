using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem.HID;
public class CardManager : MonoSingleton<CardManager>
{
    string[] var;
    [SerializeField] private List<GameObject> _well = null;
    [SerializeField] private GameObject _CardPrefab = null;
    private Transform child = null;
    public float duration = 0.2f;
    public float range = 10f;
    [SerializeField] private CardSO Sprite = null;
    [SerializeField] private AwakeSO[] RandomCardSO = null;
   public CardCheacker[] _cheack = null;
   [SerializeField] PlayerDataSO _playerDataSO = null;
    GameObject Obiion;
    int spriteRand = 0;
    private void Awake()
    {_well = new List<GameObject>(2);
        _cheack = new CardCheacker[3];
        child= transform.GetChild(0);
        for (int i = 0; i <= 2; i++)
        { _well.Add(Instantiate(_CardPrefab, transform));
            _well[i].transform.GetChild(0).gameObject.AddComponent<CardCheacker>();
            _cheack[i] = _well[i].transform.GetChild(0).GetComponent<CardCheacker>();
            _cheack[i]._OnClick += RandomSprite;
            _well[i].GetComponent<Canvas>().worldCamera = Camera.main;
            _well[i] = _well[i].transform.GetChild(0).gameObject;
        }
        StartCardPolling();
    }
    public void StartCardPolling()
    { for (int i = 0; i < 3; i++)
            _well[i].transform.DOMove(new Vector3(_well[i].transform.position.x * i * range, child.transform.position.y, _well[i].transform.position.z), duration);
        _well[1].transform.DOMove(new Vector3(_well[1].transform.position.x * 1 * -100, child.transform.position.y, _well[1].transform.position.z), duration);
        BackSpriteFOr();
    }

    public void EndCardPolling()
    { // 어 여기가 끝났을때
        for (int i = 0; i < 3; i++)
            _well[i].transform.DOMove(new Vector3(_well[i].transform.position.x * i * range, child.transform.position.y - 100, _well[i].transform.position.z), duration);
        _well[1].transform.DOMove(new Vector3(_well[1].transform.position.x * 1 * -100, child.transform.position.y, _well[1].transform.position.z), duration);
        BackSpriteFOr();
        var = null;
    }
    public void BackSpriteFOr()
    {for (int i = 0; i < 3; i++)
        {_well[i].transform.DOScaleX(0.18f, duration);
            _well[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            _well[i].GetComponent<Image>().sprite = Sprite.BackSprite;
            _well[i].transform.GetChild(1).gameObject.SetActive(false);

        }   
    }
    public void FrontSprite<T>(T target) where T : Component
    {child = target.transform.GetChild(0);
        ChildChange(-2f,true,Sprite.FrontSprite);
    }
    private void ChildChange(float end,bool flag,Sprite sprite)
    {child.DOScaleX(end, duration).OnComplete(()=> child.DOPause());
        child.GetChild(0).gameObject.SetActive(flag);
        child.GetComponent<Image>().sprite = sprite;
        

    }

    public void GameobjectGet(GameObject obj,bool flag)
    {
        if (Obiion == null)
        {
            Debug.LogError("이거는 아무것도 없습니다.");
            return;
        }
         obj.gameObject.SetActive(flag);
        Obiion = obj;

    }

    public void RandomSprite()
    { int stage = 0;
          if (stage == 0)
            Stage0();
        if (stage == 1)
            Stage1();
        if (stage == 2)
            Stage2();
    }
    private void Stage2()
    { int rand = Random.Range(0, 101);
        if (rand <= 45)
        EnterChange("Common");
        if (rand > 45 && rand < 85)
         EnterChange("Rare");
        if (rand >= 85)
         EnterChange("Legend");
 }
    private void Stage1()
    {
        int rand = Random.Range(0, 101);
        if (rand <= 65)
        EnterChange("Common");
       if (rand > 65 && rand < 90)
         EnterChange("Rare");
       if ( rand >= 90)
         EnterChange("Legend");    
    }
    public void Stage0()
    {int rand = Random.Range(0, 101);
        if (rand <= 80)
        EnterChange("Common");
        if (rand > 80)
        EnterChange("Rare");
    }
    private void EnterChange<T>(T t)
    {
        RandomCardSO = Resources.LoadAll<AwakeSO>($"RandomSprite/{t}");
        spriteRand = Random.Range(0, RandomCardSO.Length);
        child.GetChild(0).GetComponent<Image>().sprite = RandomCardSO[spriteRand].sprite;
        var = new string[]
        {
            RandomCardSO[spriteRand].Name,
            "공격력:" + _playerDataSO.Damage + RandomCardSO[spriteRand].Attack / 100 * _playerDataSO.Damage +"%",
            "체력:" +_playerDataSO.Hp + RandomCardSO[spriteRand].Health/ 100 * _playerDataSO.Hp + "%",
            "공격속도:" +_playerDataSO.SwordAttackTime + RandomCardSO[spriteRand].AttackSpeed/100 * _playerDataSO.SwordAttackTime + "%",
            "이동속도:" +_playerDataSO.MoveSpeed + RandomCardSO[spriteRand].speed/100*_playerDataSO.MoveSpeed + "%"
        };
        for (int i = 0; i < var.Length; i++)
        { 
            child.GetChild(0).GetChild(i).GetComponent<TextMeshProUGUI>().text = var[i];
        }
      
        Obiion.gameObject.SetActive(true);
        string text = RandomCardSO[spriteRand].Text;
       Ob(text);
        
  
    }

   private void Ob(string text)
    {
        Obiion.GetComponent<TextMeshProUGUI>().DOText(text, 1f);
    }

 
}