using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : AudioTemplate
{
    public static MusicHandler instance;

    // array that holds the music files
    [SerializeField]
    new Audio[] audio = null;

    void Start()
    {
        // loop through the music array and bind it
        for (int i = 0; i < audio.Length; i++)
        {
            GameObject bindAudio = new GameObject("Sound_"+i+"_"+audio[i].fileName);
            bindAudio.transform.SetParent(this.transform);
            audio[i].SetSource(bindAudio.AddComponent<AudioSource>());
        }

        // music to play from start
        InitAudio();
    }

    // ensures a single instance on the bound object
    // SINGLETON PATTERN
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // music should always loop
    public override void LoopAudio(int index)
    {
        if (!audio[index].loop)
            audio[index].loop = true;
    }

    // play music based on name
    public override void PlayAudio(string name)
    {
        for (int i = 0; i < audio.Length; i++)
        {
            // a match found, apply parameters and play it
            if (name == audio[i].fileName)
            {
                LoopAudio(i);
                PitchAudio();
                audio[i].Play();
                return;
            }
        }
    }

    // pause music based on name
    public void PauseAudio(string name)
    {
        for (int i = 0; i < audio.Length; i++)
        {
            // a match found, apply parameters and play it
            if (name == audio[i].fileName)
            {
                audio[i].Pause();
                return;
            }
        }
    }

    // starts playing first music file
    public void InitAudio()
    {
        audio[0].Play();
    }
}