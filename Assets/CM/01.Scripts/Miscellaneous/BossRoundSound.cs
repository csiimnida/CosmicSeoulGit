using UnityEngine;
using DG.Tweening;
public class BossRoundSound : MonoBehaviour{
    [SerializeField] private AudioSource _backgroundBGM;
    [SerializeField] private AudioSource _bossBGM;
    [SerializeField] private float _fadeDuration = 3f;

    private void Start(){
        SoundSet();
    }

    private void SoundSet()
    {
        _backgroundBGM.DOFade(0f, _fadeDuration).OnComplete(() => {
            _bossBGM.time = 0f;
            _bossBGM.DOFade(1f, _fadeDuration);
        });
    }
}
