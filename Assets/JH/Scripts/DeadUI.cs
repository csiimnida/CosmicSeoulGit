using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DeadUI : MonoBehaviour{
    private Camera _camera;
    [SerializeField] private VolumeProfile _profile;
    private Volume _volume;
    private Bloom _bloom;
    private Vignette _vignette;
    private Tonemapping _tonemapping;
    private ColorAdjustments _colorAdjustments;
    private Player _player;

    private void Awake(){
        Debug.Log(_player);
        
        if (_profile.TryGet(out _bloom))
        {
            _bloom.threshold.value = 1f; // 기본 임계값
            _bloom.intensity.value = 0f; // 기본 강도
            _bloom.scatter.value = 0.5f; // 기본 스캐터링
            _bloom.tint.value = new Color(1, 1, 1); // 기본 색상 (흰색)
            //_volume.enabled = false;
        }
        else
        {
            Debug.LogWarning("VolumeProfile에 Bloom 효과가 없습니다.");
        }

        if (_profile.TryGet(out _vignette))
        {
            _vignette.color.value = new Color(0, 0, 0); // 기본 검은색
            _vignette.center.value = new Vector2(0.5f, 0.5f); // 화면 중심
            _vignette.intensity.value = 0f; // 기본 강도
            _vignette.smoothness.value = 0.5f; // 기본 부드러움
            //_volume.enabled = false;
        }
        else
        {
            Debug.LogWarning("VolumeProfile에 Vignette 효과가 없습니다.");
        }

        if (_profile.TryGet(out _tonemapping))
        {
            _tonemapping.mode.value = TonemappingMode.None;
        }
        else
        {
            Debug.LogWarning("VolumeProfile에 Tonemapping 효과가 없습니다.");
        }

        if (_profile.TryGet(out _colorAdjustments))
        {
            _colorAdjustments.postExposure.value = 0f;
        }
        else
        {
            Debug.LogWarning("VolumeProfile에 Tonemapping 효과가 없습니다.");
        }

        
    }

    private void Start(){
        DontDestroyOnLoad(gameObject);
        /*_player = GameManager.Instance.Player;
        _player.OnDeath += DeadEffectStart;*/
    }

    public void DeadEffectStart(){
        _camera = Camera.main;
        _volume = _camera.GetComponent<Volume>();
        StartCoroutine(ApplyVignetteEffectOverTime());
        StartCoroutine(ApplyBloomEffectOverTime());
        _tonemapping.mode.value = TonemappingMode.ACES;
    }

    private void Update(){
        if (_player == null)
        {
            try
            {
                _player = GameManager.Instance.Player;
                _player.OnDeath += DeadEffectStart;
            }
            finally{}
            
        }
    }

    private IEnumerator ApplyBloomEffectOverTime(){
        float duration = 1f; // 서서히 변화하는 데 걸리는 시간(초)
        float elapsedTime = 0f;

        // 초기값
        float startThreshold = _bloom.threshold.value;
        float startIntensity = _bloom.intensity.value;
        float startScatter = _bloom.scatter.value;
        Color startTint = _bloom.tint.value;

        // 목표값
        float targetThreshold = 0;
        float targetIntensity = 1;
        float targetScatter = 0.8f;
        Color targetTint = new Color(119 / 255f, 0, 0);

        // Volume 활성화
        _volume.enabled = true;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 0~1로 보간

            // Lerp를 사용해 서서히 값 변경
            _bloom.threshold.value = Mathf.Lerp(startThreshold, targetThreshold, t);
            _bloom.intensity.value = Mathf.Lerp(startIntensity, targetIntensity, t);
            _bloom.scatter.value = Mathf.Lerp(startScatter, targetScatter, t);
            _bloom.tint.value = Color.Lerp(startTint, targetTint, t);

            yield return null; // 다음 프레임까지 대기
        }

        // 마지막 목표값 보장
        _bloom.threshold.value = targetThreshold;
        _bloom.intensity.value = targetIntensity;
        _bloom.scatter.value = targetScatter;
        _bloom.tint.value = targetTint;
    }

    private IEnumerator ApplyVignetteEffectOverTime(){
        float duration = 1.2f; // 서서히 변화하는 데 걸리는 시간(초)
        float elapsedTime = 0f;

        // 초기값
        Color startColor = _vignette.color.value;
        Vector2 startCenter = _vignette.center.value;
        float startIntensity = _vignette.intensity.value;
        float startSmoothness = _vignette.smoothness.value;

        // 목표값
        Color targetColor = new Color(3 / 255f, 0, 0); // 목표 색상
        Vector2 targetCenter = new Vector2(0.5f, 0.21f); // 목표 중심
        float targetIntensity = 1f; // 목표 강도
        float targetSmoothness = 1f; // 목표 부드러움

        // Volume 활성화
        _volume.enabled = true;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 0~1로 보간

            // Lerp를 사용해 서서히 값 변경
            _vignette.color.value = Color.Lerp(startColor, targetColor, t);
            _vignette.center.value = Vector2.Lerp(startCenter, targetCenter, t);
            _vignette.intensity.value = Mathf.Lerp(startIntensity, targetIntensity, t);
            _vignette.smoothness.value = Mathf.Lerp(startSmoothness, targetSmoothness, t);

            yield return null; // 다음 프레임까지 대기
        }

        // 마지막 목표값 보장
        _vignette.color.value = targetColor;
        _vignette.center.value = targetCenter;
        _vignette.intensity.value = targetIntensity;
        _vignette.smoothness.value = targetSmoothness;

        yield return new WaitForSeconds(2f);
        StartCoroutine(ReviveEffect());
    }

    private IEnumerator ReviveEffect(){
        float duration = 3f; // 서서히 변화하는 데 걸리는 시간(초)
        float elapsedTime = 0f;

        // 초기값

        float startPostExposure = _colorAdjustments.postExposure.value;


        // 목표값

        float targetPostExposure = -10f;


        // Volume 활성화
        _volume.enabled = true;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 0~1로 보간

            // Lerp를 사용해 서서히 값 변경

            _colorAdjustments.postExposure.value = Mathf.Lerp(startPostExposure, targetPostExposure, t);


            yield return null; // 다음 프레임까지 대기
        }
        Destroy(GameManager.Instance.Player.gameObject);
        Save.Instance.LoadButtn();

        // 마지막 목표값 보장

        _colorAdjustments.postExposure.value = targetPostExposure;
    }
}