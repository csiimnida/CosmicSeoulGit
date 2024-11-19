using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awake : MonoBehaviour
{
    public List<AwakeSO> _awake;
    Image _image;
private void Start()
    { 
        _image = GetComponent<Image>(); 
        RandomAwake();
    }

    public void RandomAwake()
    {int rand = Random.Range(0,_awake.Count-1);
        _image.sprite = _awake[rand].sprites;
    }
}
