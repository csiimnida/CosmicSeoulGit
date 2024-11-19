using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TypingManager : MonoBehaviour
{
    public List<AwakeSO> _awakeSO;
    public TextMeshProUGUI Text;
    [SerializeField] private AwakeCard _awake;



    public void _Typing()
    {
        Text.DOText(_awakeSO[_awake.rand].Text,0.5f);
        //StartCoroutine(_typing());

    }

    public void _TypingStop()
    {
        Text.text = "";
        //StopCoroutine(_typing());
    }

    IEnumerator _typing()
    {
       Debug.Log(_awakeSO[_awake.rand]);
            for (int i = 0; i <= _awakeSO[_awake.rand].Text.Length; i++)
            {
            
                Text.text = _awakeSO[_awake.rand].Text.Substring(0, i);
                yield return new WaitForSeconds(0.1f);
            }
     
       
    }
}
