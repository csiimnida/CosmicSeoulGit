using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingSound : MonoBehaviour
{
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private UnityEngine.Audio.AudioMixer AudioMixer;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGM", 0.5f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFX", 0.5f);
    }
    public void SetBGMValue(float BGMSliderValue)
    {
        
        AudioMixer.SetFloat("BGM", Mathf.Log10(BGMSliderValue) * 20);
        PlayerPrefs.SetFloat("BGM", BGMSliderValue);
    }
    public void SetSFXValue(float SFXSliderValue)
    {

        AudioMixer.SetFloat("SFX", Mathf.Log10(SFXSliderValue) * 20);
        PlayerPrefs.SetFloat("SFX", SFXSliderValue);
    }
}
