using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.IO;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using System.Text.RegularExpressions;
public class CardManager : MonoSingleton<CardManager>
{

    string[] var = null;
    [SerializeField] private List<GameObject> _well = null;
    [SerializeField] private GameObject _CardPrefab = null;
    private Transform child = null;
    public float duration = 0.2f;
    [SerializeField] private CardSO Sprite = null;
    [SerializeField] private AwakeSO[] RandomCardSO = null;
    public CardCheacker[] _cheack = null;
    [SerializeField] PlayerDataSO _playerDataSO = null;
    GameObject Obiion;
    int spriterand= 0;
    [SerializeField] private Transform EndTarget;
    [SerializeField] private Transform Target;
    private Player _player;
    private CheckLevelUp _checkLevelUp;
    private int a = 0;
    public int stage = 0;
public GameObject[] volumes;
    private void Awake()
    {
        _well = new List<GameObject>(2);
        _cheack = new CardCheacker[3];
        child= transform.GetChild(0);
     
    }

    private void Start()
    {
        _player = GameManager.Instance.Player;
        _checkLevelUp = _player.GetComponentInChildren<CheckLevelUp>();
        _checkLevelUp.OnLevelUp.AddListener(StartCardPolling);
        for (int i = 0; i <= 1; i++)
        {
            volumes[i].GetComponent<Volume>().enabled = false;
        }
        
        volumes[0].SetActive(true);
        volumes[1].SetActive(false);
    }

    public void StartCardPolling(int a)
    {
        _well = new List<GameObject>(2);
        _cheack = new CardCheacker[3];
        for (int i = 0; i <= 2; i++)
        {
            _well.Add(Instantiate(_CardPrefab, transform));
         
            _cheack[i] = _well[i].transform.GetChild(0).GetComponent<CardCheacker>();
            _cheack[i]._OnClick += RandomSprite;
            _well[i].GetComponentInParent<Canvas>().worldCamera = Camera.main;
            _well[i] = _well[i].transform.GetChild(0).gameObject;
        }
        _well[1].transform.DOMove(new Vector3((Target.position.x * 0) *0.5f, Target.position.y, Target.position.z), duration);
        _well[2].transform.DOMove(new Vector3((Target.position.x * 1) * -0.5f, Target.position.y, Target.position.z), duration);
        _well[0].transform.DOMove(new Vector3((Target.position.x * 1) * 0.5f, Target.position.y, Target.position.z), duration).OnComplete(
            () =>
            {
               

            });
       BackSpriteFOr();
        volumes[0].GetComponent<Volume>().enabled = true;
    }

    public void EndCardPolling()
    { // �� ���Ⱑ ��������
      
        for (int i = 0; i < 3; i++)
            _well[i].transform.DOMove(new Vector3(EndTarget.position.x, EndTarget.position.y - 75, EndTarget.position.z), duration).OnComplete(() =>
            {
                for (int i = 0; i < 3; i++)
                    Destroy(_well[i].transform.parent.gameObject);
                _well = null;
                _cheack = null;
                _cheack[i]._OnClick -= RandomSprite;
            });

        volumes[0].GetComponent<Volume>().enabled = false;

    }
    public void BackSpriteFOr()
    {for (int i = 0; i < 3; i++)
        {_well[i].transform.DOScaleX(0.18f, duration);
            _well[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            _well[i].transform.GetChild(0).GetComponent<Image>().sprite = Sprite.BackSprite;
            _well[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }   
    }
    public void FrontSprite<T>(T target) where T : Component
    {child = target.transform.GetChild(0);
        ChildChange(-2f,true,Sprite.FrontSprite);
     
    }
    private void ChildChange(float end,bool flag,Sprite sprite)
    {child.DOScaleX(end, duration);
        child.GetChild(0).gameObject.SetActive(flag);
        child.GetComponent<Image>().sprite = sprite;
        

    }

    public void GameobjectGet(GameObject obj,bool flag)
    {
        try
        {
            obj.gameObject.SetActive(flag);
            Obiion = obj;
        }
        catch (NullReferenceException)
        {

            Debug.LogError("null");
            return;

        } 
    
    }

    public void RandomSprite()
    { 
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
        if (rand is > 65 and < 90)
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
    {RandomCardSO = Resources.LoadAll<AwakeSO>($"RandomSprite/{t}");
        Debug.Log(RandomCardSO.Length);
        spriterand = Random.Range(0, RandomCardSO.Length);
        child.GetChild(0).GetComponent<Image>().sprite = RandomCardSO[spriterand].sprite;
       
        var = new string[]
        {
            RandomCardSO[spriterand].Name,
            "공격력:" + RandomCardSO[spriterand].Attack  +"%",
            "이동 속도:" + RandomCardSO[spriterand].speed + "%",
            "공격 속도:" + RandomCardSO[spriterand].AttackSpeed + "%",
             "체력:" +RandomCardSO[spriterand].Health + "%",
        };
        for (int i = 0; i < var.Length; i++)
        { 
            child.GetChild(0).GetChild(i).GetComponent<TextMeshProUGUI>().text = var[i];
            
          
        }
       

        // 텍스트 파일로 저장
     

        //Debug.Log("Data saved to: " + path);
        Obiion.gameObject.SetActive(true);
        string text = RandomCardSO[spriterand].Text;
       Ob(text);
        
  
    }

   private void Ob(string text)
    {
        Obiion.GetComponent<TextMeshProUGUI>().DOText(text, 1f);
    }

   
    public void Enter()
    {
        _playerDataSO.Damage += _playerDataSO.Damage*float.Parse(Regex.Match(child.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text, @"\d+").Value)/ 100;
        _playerDataSO.Hp += _playerDataSO.Hp*float.Parse(Regex.Match(child.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text, @"\d+").Value)/ 100;
        _playerDataSO.SwordAttackTime += _playerDataSO.SwordAttackTime*float.Parse(Regex.Match(child.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text, @"\d+").Value)/ 100;
        _playerDataSO.MoveSpeed += _playerDataSO.MoveSpeed*float.Parse(Regex.Match(child.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text, @"\d+").Value) / 100;
        
    }
 
}