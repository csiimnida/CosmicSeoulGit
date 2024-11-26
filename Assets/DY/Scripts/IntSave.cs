using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasySave.Json;

public class IntSave : MonoBehaviour
{
    private class Intdata
    {
        public int datacode;
    }
    private void Start()
    {
        Intdata intdata = new Intdata();
        intdata.datacode = 0;
        EasyToJson.ToJson<Intdata>(intdata,"IntData",true);
    }

    private void LoadData()
    {
        print(EasyToJson.FromJson<Intdata>("IntData"));
    }
}
