using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCredit : MonoBehaviour
{
    
    [SerializeField] public GameObject Creditpanel;

    // Start is called before the first frame update
    void Start()
    {
        if (Creditpanel != null)
        {
            Creditpanel.SetActive(false);
        }
        
    }

    public void OnCreditUI()
    {
        Creditpanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
