using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TutorialPopUpData",menuName ="ScriptableObjects/newTutorialPopUpData")]
public class TutorialPopUpSO : ScriptableObject
{
    public string VideoClipName;
    public RenderTexture RenderTexture;
}
