using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPostionSetting : MonoBehaviour
{
    private Player player;
    private void Start(){
        player = GameManager.Instance.Player;
        player.transform.position = transform.position;
    }
}
