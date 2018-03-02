using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class StoryTeller : MonoBehaviour
{

    public Story[] historias;
    private AudioSource source;

    private Story _currentStory;
    private int storyIndex = 0;

    public Text texto;

    public Story CurrentStory
    {
        get { return _currentStory; }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        Shuffle(historias);

        EventManager.TimeUp += AssignNextStory;
    }

    public void Shuffle(Story[] list)
    {
        int n = list.Length;
        while (n > 1)
        {
            System.Random rng = new System.Random();
            n--;
            int k = rng.Next(n + 1);
            Story value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void AssignNextStory()
    {
        _currentStory = historias[storyIndex];
        source.clip = _currentStory.audio;

        texto.text = _currentStory.transcription;

        source.Play();

        storyIndex++;
    }
}
