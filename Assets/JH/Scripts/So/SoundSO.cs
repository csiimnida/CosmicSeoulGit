using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Sound")]
public class SoundSO : ScriptableObject
{

    public string SoundName;

    public string SoundType;

    public AudioClip AudioClip;

    public enum SoundTypes
    {
        BGM,
        ClickSFX,
        NormalSFX,
    }
}
