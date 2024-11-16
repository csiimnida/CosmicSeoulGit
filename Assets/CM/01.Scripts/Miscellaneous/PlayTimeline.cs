using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeline : MonoBehaviour
{
    private PlayableDirector _playableDirector;
    private bool check = false;

    private void Awake(){
        _playableDirector = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && check == false)
        {
            _playableDirector.Play();
            check = true;
        }
    }
}
