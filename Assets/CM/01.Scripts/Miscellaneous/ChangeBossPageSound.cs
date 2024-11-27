using DG.Tweening;
using UnityEngine;

public class ChangeBossPageSound : MonoBehaviour
{
    [SerializeField] private AudioSource _firstPageSound;
    [SerializeField] private AudioSource _secondPageSound;
    [SerializeField] private float _fadeDuration = 3f;

    public void PlayChangePageSound(){
        SoundSet();
    }

    private void SoundSet()
    {
        _firstPageSound.DOFade(0f, _fadeDuration).OnComplete(() => {
            _secondPageSound.time = 0f;
            _secondPageSound.DOFade(1f, _fadeDuration);
        });
    }
}
