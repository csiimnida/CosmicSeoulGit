using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardData
{
    public string Name;
    public float Attack;
    public float speed;
    public float AttackSpeed;
    public float Health;
    public float Text;
}
public class CardCheacker : MonoBehaviour , IPointerEnterHandler, IPointerDownHandler , IPointerExitHandler
{
    private int  count = 0;
    private bool hasPointerEntered = false; // ?÷??? ????
    private bool hasPointer = false;
    private Vector2 currentSize = Vector2.zero;
    private RectTransform rect = null;
    private Tween scaleTween = null;
    private bool isClick = false;
    [SerializeField] private Sprite frontimage;
    private CardData _data;
    private TextMeshProUGUI _tmp;
    private bool isFront;
    
    


    private void Awake()
    {
        rect =transform.GetChild(0).GetComponent<RectTransform>();
        _tmp = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        currentSize = rect.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!hasPointer)
        { 
            hasPointer = true;
            scaleTween?.Kill();
            _tmp.gameObject.SetActive(true);//Text
        }

    }

     public void OnPointerExit(PointerEventData eventData)
    {
        if (hasPointer)
        { 
            hasPointer = false;
            scaleTween?.Kill();
            _tmp.gameObject.SetActive(false);//Text
            _tmp.text = "";
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {   
        ChildChange(true,transform.GetChild(0));
        if (isFront)
        { 
            CardManager.Instance.Enter(_data);
            CardManager.Instance.EndCardPolling();
            isFront = false;
           
        }
        isFront = true;
        
    }
    private void ChildChange(bool flag,Transform child)
    {
        child.DOScaleX(0f, 0.2f).SetUpdate(true).OnComplete(() =>
        {
            RandomSprite();
            child.DOScaleX(-2f, 0.2f).SetUpdate(true);  
            child.GetChild(0).gameObject.SetActive(flag);
        });
    }
    public void RandomSprite()
    {
        int stage = CardManager.Instance.stage;
        if (stage == 0)
            Stage0();
        if (stage == 1)
            Stage1();
        if (stage == 2)
            Stage2();
    }
    private void Stage2()
    { 
        int rand = Random.Range(0, 101);
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
    
    private void EnterChange(string t)
    {
        AwakeSO[] _randomCardSO = Resources.LoadAll<AwakeSO>($"RandomSprite/{t}");
        int spriterand = Random.Range(0, _randomCardSO.Length);
        AwakeSO card = _randomCardSO[spriterand];
        
        Transform childs = transform.GetChild(0).GetChild(0);
        
        childs.GetComponent<Image>().sprite = card.sprite;
        transform.GetChild(0).GetComponent<Image>().sprite = frontimage;
        childs.GetChild(0).GetComponent<TextMeshProUGUI>().text = card.Name;
        childs.GetChild(1).GetComponent<TextMeshProUGUI>().text = "공격력:" + card.Attack  +"%";
        childs.GetChild(2).GetComponent<TextMeshProUGUI>().text = "이동 속도:" + card.speed + "%";
        childs.GetChild(3).GetComponent<TextMeshProUGUI>().text = "공격 속도:" + card.AttackSpeed + "%";
        childs.GetChild(4).GetComponent<TextMeshProUGUI>().text = "체력:" +card.Health + "%";
       

        transform.GetChild(1).gameObject.SetActive(true);
        _data = new CardData();
        _data.Name = card.Name;
        _data.Attack = card.Attack;
        _data.speed = card.speed;
        _data.AttackSpeed = card.AttackSpeed;
        _data.Health = card.Health;
        
        SetText(_data.Name);
        
    }


    private void SetText(string text)
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().DOText(text, 1f).SetUpdate(true);
    }
}
