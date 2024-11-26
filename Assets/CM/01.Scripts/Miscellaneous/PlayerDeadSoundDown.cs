using System;
using System.Collections;
using UnityEngine;

public class PlayerDeadSoundDown : MonoBehaviour
{

    private Player player;

    private void OnEnable(){
        player = GameManager.Instance.Player;
        player.OnDeath += PlayerDeadSoundDownMethod;
    }

    public void PlayerDeadSoundDownMethod(){
        StartCoroutine(SoundDown());
    }
    
    private IEnumerator SoundDown(){
        for (int i = 0; i < 100; i++)
        {
            AudioListener.volume -= 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnDestroy(){
        player.OnDeath -= PlayerDeadSoundDownMethod;
    }
}
