using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeline : MonoBehaviour
{
    private PlayableDirector _playableDirector;
    private bool check = false;
    private Player _player;
    [SerializeField] private Transform _checker;

    private void Awake(){
        _playableDirector = GetComponent<PlayableDirector>();
    }

    private void Start(){
        _player = GameManager.Instance.Player;
    }

    private void Update(){
        if (_checker.position.x <= _player.transform.position.x && check == false)
        {
            _playableDirector.Play();
            check = true;
        }
    }
}
