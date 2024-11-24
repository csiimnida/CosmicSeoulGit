using UnityEngine;


[CreateAssetMenu(menuName = "SO/Sound")]
public class SoundSO : ScriptableObject
{

    public string SoundName;

    public string SoundType;

    public AudioClip AudioClip;

    [Range(0,100)] public float SoundProportion;

    public enum SoundTypes
    {
        BGM,
        SFX
    }
}
