using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PlayableEnd : MonoBehaviour{
    public UnityEvent OnEnd;

    private void OnEnable(){
        OnEnd?.Invoke();
    }
}
