using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story")]
public class Story : ScriptableObject {

    public new AudioClip audio;
    public string transcription;
    public string url;
}
