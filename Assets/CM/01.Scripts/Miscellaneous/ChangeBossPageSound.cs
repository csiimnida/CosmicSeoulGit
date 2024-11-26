using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBossPageSound : MonoBehaviour
{
    [SerializeField] private AudioSource _firstPageSound;
    [SerializeField] private AudioSource _secondPageSound;
    [SerializeField] private float _fadeDuration = 3f;

    public void PlayChangePageSound(){
        StartCoroutine(SoundDown());
    }

    private IEnumerator SoundDown()
    {
        _secondPageSound.gameObject.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            _firstPageSound.volume -= 0.01f;
            _secondPageSound.volume += 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        _firstPageSound.volume = 0f;
        _secondPageSound.volume = 1f;
        yield return new WaitForSeconds(_fadeDuration + 0.5f);
    }
}
