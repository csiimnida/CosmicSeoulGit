using System;
using System.Collections;
using UnityEngine;

public class PlayerDeadSoundDown : MonoBehaviour
{

    private Player player;

    private void Update(){
        if(player != null) return;
        player = GameManager.Instance.Player;
        player.OnDeath += PlayerDeadSoundDownMethod;
    }

    public void PlayerDeadSoundDownMethod(){
        StartCoroutine(SoundDown());
    }
    
    private IEnumerator SoundDown(){
        for (int i = 0; i < 100; i++)
        {
            if (AudioListener.volume < 0)
            {
                AudioListener.volume = 0;
                break;
            }
            AudioListener.volume -= 0.01f;
            yield return new WaitForSeconds(0.05f);
            Destroy(gameObject);
        }
    }

    private void OnDestroy(){
        player.OnDeath -= PlayerDeadSoundDownMethod;
    }
}
