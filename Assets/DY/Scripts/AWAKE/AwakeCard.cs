using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeCard : MonoBehaviour
{
    public List<AwakeSO> _awake;
    Image _image;
   [SerializeField] Text _text;
   [SerializeField] Text _Attacktext;
   [SerializeField] Text _Healthtext;
   [SerializeField] Text _AttackSpdtext;
   [SerializeField] Text _WalkSpdtext;
   public int rand = 0;
    private void Awake()
    {
        _image = GetComponent<Image>();
        RandomAwake();
    }

    public void RandomAwake()
    { rand = Random.Range(0,_awake.Count);
        _image.sprite = _awake[rand].sprites;
        _text.text = _awake[rand].Name;
        _Attacktext.text ="공격력: "+ _awake[rand].Attack.ToString() + "%";
        _Healthtext.text = "체력: "+_awake[rand].Defende.ToString() + "%";
        _AttackSpdtext.text = "공격속도: "+_awake[rand].AttackAirSpeed.ToString() + "%";
        _WalkSpdtext.text = "이동속도: "+_awake[rand].MoveSpeed.ToString() + "%";
        Debug.Log(_awake[rand]);
    }
}
