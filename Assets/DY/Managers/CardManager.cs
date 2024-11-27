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
using UnityEngine.Serialization;

public class CardManager : MonoSingleton<CardManager>
{

    [SerializeField] private List<GameObject> _well = null;
    [SerializeField] private GameObject _CardPrefab = null;
    [FormerlySerializedAs("Sprite")] [SerializeField] private CardSO cardSo = null;
    [SerializeField] private AwakeSO[] RandomCardSO = null;
    public CardCheacker[] _cheack = null;
    [SerializeField] PlayerDataSO _playerDataSO = null;
    static int spriterand= 0;
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
     
    }

    private void Start()
    {
        for (int i = 0; i <= 1; i++)
        {
            volumes[i].GetComponent<Volume>().enabled = false;
        }
        
        volumes[0].SetActive(true);
        volumes[1].SetActive(false);
    }


    private void Update()
    {
        if (_player == null)
        {
            try
            {
                _player = GameManager.Instance.Player;
                _checkLevelUp = _player.GetComponentInChildren<CheckLevelUp>();
                _checkLevelUp.OnLevelUp.AddListener(StartCardPolling);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public void StartCardPolling(int a)
    {
        _well = new List<GameObject>(2);
        _cheack = new CardCheacker[3];

        // 카드 생성 및 초기화
        for (int i = 0; i <= 2; i++)
        {
            _well.Add(Instantiate(_CardPrefab, transform));
            _cheack[i] = _well[i].transform.GetChild(0).GetComponent<CardCheacker>();
            _well[i].GetComponentInParent<Canvas>().worldCamera = Camera.main;
            _well[i] = _well[i].transform.GetChild(0).gameObject;
        }

        float fixedOffset = 500f; // 카드 간의 고정 간격 (UI 기준)
        Vector2 targetCanvasPosition;

        // 월드 좌표 -> 스크린 좌표 -> 캔버스 로컬 좌표 변환
        RectTransform canvasRect = _well[1].GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            Camera.main.WorldToScreenPoint(Target.position),
            Camera.main,
            out targetCanvasPosition
        );
        Time.timeScale = 0;
        // 기준 위치 (중앙 카드의 위치)
        float baseX = targetCanvasPosition.x;

        // 중앙 카드 배치
        _well[1].GetComponent<RectTransform>().DOAnchorPos(new Vector2(baseX, targetCanvasPosition.y), 0.2f).SetUpdate(true);

        // 오른쪽 카드 배치
        _well[2].GetComponent<RectTransform>().DOAnchorPos(new Vector2(baseX + fixedOffset, targetCanvasPosition.y), 0.2f).SetUpdate(true);

        // 왼쪽 카드 배치
        _well[0].GetComponent<RectTransform>().DOAnchorPos(new Vector2(baseX - fixedOffset, targetCanvasPosition.y), 0.2f).SetUpdate(true).OnComplete(() =>
        {
            // 애니메이션 완료 후 수행할 작업
        });

        volumes[0].GetComponent<Volume>().enabled = true;
        // 카드 초기화
        BackSpriteFOr();
    }

    public void EndCardPolling()
    { 
        Time.timeScale = 1;
        for (int i = 0; i < 3; i++)
            _well[i].transform.DOMove(new Vector3(EndTarget.position.x, EndTarget.position.y - 75, EndTarget.position.z), 0.2f).SetUpdate(true).OnComplete(() =>
            {
                for (int i = 0; i < 3; i++)
                    Destroy(_well[i].transform.parent.gameObject);
                _well = null;
                _cheack = null;
            });

        volumes[0].GetComponent<Volume>().enabled = false;

    }
    public void BackSpriteFOr()
    {
        for (int i = 0; i < 3; i++)
        {
            _well[i].transform.DOScaleX(0.18f, 0.2f).SetUpdate(true);
            _well[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }   
    }
    public void FrontSprite<T>(T target) where T : Component
    {
    }
    






   
    public void Enter(CardData cardData)
    {

        PrintStat();
        _playerDataSO.Damage += _playerDataSO.Damage*(cardData.Attack/ 100);
        _playerDataSO.Hp += _playerDataSO.Hp*cardData.Health/ 100;
        _playerDataSO.SwordAttackTime += cardData.AttackSpeed/ 100;
        _playerDataSO.MoveSpeed += cardData.speed / 100;
        PrintStat();
    }

    private void PrintStat()
    {
        Debug.Log(_playerDataSO.Damage);
        Debug.Log(_playerDataSO.Hp);
        Debug.Log(_playerDataSO.SwordAttackTime);
        Debug.Log(_playerDataSO.MoveSpeed);
        Debug.Log("-------------------------");
    }

}