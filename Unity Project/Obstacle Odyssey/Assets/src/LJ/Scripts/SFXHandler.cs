using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : AudioTemplate
{
    public static SFXHandler instance;

    // array that holds the sfx files
    [SerializeField]
    new Audio[] audio = null;

    void Start()
    {
        // loop through the sfx array and bind it
        for (int i = 0; i < audio.Length; i++)
        {
            GameObject bindAudio = new GameObject("Sound_"+i+"_"+audio[i].fileName);
            bindAudio.transform.SetParent(this.transform);
            audio[i].SetSource(bindAudio.AddComponent<AudioSource>());
        }
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

    // sfx should not loop
    public override void LoopAudio(int index)
    {
        if (audio[index].loop)
            audio[index].loop = false;
    }

    // random pitch system for sfx
    public override float PitchAudio()
    {
        return Random.Range(0.5F, 1.5F);
    }

    // play sfx based on name
    public override void PlayAudio(string name)
    {
        for (int i = 0; i < audio.Length; i++)
        {
            // a match found, apply parameters and play it
            if (name == audio[i].fileName)
            {
                LoopAudio(i);
                audio[i].pitch = PitchAudio();
                audio[i].Play();
                return;
            }
        }
    }
}