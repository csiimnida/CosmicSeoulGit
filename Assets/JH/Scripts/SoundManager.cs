using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SoundManager : MonoSingleton<SoundManager>
{
    
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private UnityEngine.Audio.AudioMixer AudioMixer;
    [SerializeField] private JHSoundSO Sounds;

    private Dictionary<string, SoundSO> _dictionary = new Dictionary<string, SoundSO>();

    void Awake()
    {
        foreach (SoundSO item in Sounds.SoundSOs)
        {
            _dictionary.Add(item.SoundName, item);
        }
        PlaySound("StartBGM");
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "JHStart")//<=Start
        {
            bgmSource.clip = null;
        }

        if(scene.name=="JHGame")//<=Ingame
        {
            PlaySound("IngameBGM");

        }
        

    }
    public void PlaySound(string soundName)
    {
        try
        {
            if(!_dictionary[soundName])
            {
                Debug.LogError($"Sound {soundName} not found");
                return; 
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Sound {soundName} not found,, ERROR CODE: {e}");
            return;
        }
        
        if (_dictionary[soundName].SoundType == "SFX")
        {
            PlaySFX(_dictionary[soundName]);
        }else if (_dictionary[soundName].SoundType == "BGM")
        {
            PlayBGM(_dictionary[soundName].AudioClip);
        }
        else
        {
            Debug.LogError($"{_dictionary[soundName].SoundType}이 알맞지 않습니다.");
        }
    }
    
    
    public void PlaySFX(SoundSO SoundData)
    {
        AudioClip clip = SoundData.AudioClip;

        if (clip != null)
        {
            AudioMixerGroup[] groups = AudioMixer.FindMatchingGroups(SoundData.SoundType);

            GameObject sfxObject = new GameObject($"SFX_{SoundData.SoundType}");
            AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.outputAudioMixerGroup = groups[0];
            audioSource.volume = SoundData.SoundProportion * 0.01f;
            audioSource.Play();

            Destroy(sfxObject, clip.length); 
        }
        else
        {
            Debug.LogWarning($"'{SoundData.SoundName}'��� �̸��� SFX�� ã�� �� �����ϴ�.");
        }
    }

    
    public void PlayBGM(AudioClip bgmClip)
    {
        if (bgmSource != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning("BGM ����� �ҽ��� �������� �ʾҽ��ϴ�.");
        }
    }

    
    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }
    
}
