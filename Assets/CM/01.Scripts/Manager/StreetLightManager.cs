using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLightManager : MonoBehaviour
{
    [SerializeField] private GameObject streetLight;
    [SerializeField] private int _creatCount;
    [SerializeField] private float _creatDistanceValue = 12;
    private float _creatDistance = 0;

    private void Start(){
        for (int i = 0; i < _creatCount; i++)
        {
            Instantiate(streetLight, new Vector2(streetLight.transform.position.x + _creatDistance, streetLight.transform.position.y), Quaternion.identity);
            _creatDistance += _creatDistanceValue;
        }
    }
}
