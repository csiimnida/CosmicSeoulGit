using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TutorialText")]
public class TutorialTextSO : ScriptableObject
{
    public List<string> TutorialTexts = new List<string>();
}
