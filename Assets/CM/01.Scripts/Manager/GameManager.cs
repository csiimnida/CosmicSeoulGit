using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    
    public Player Player;
    public void ResetPlayer()
    {
        
    }

    private void Awake()
    {
        //if(GameObject.find)
        Player = GameObject.Find("Player").GetComponent<Player>();
        print("AWAKE");
    }

    private void OnEnable()
    {
        print("이이이");
    }

}
