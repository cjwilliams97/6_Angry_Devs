using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceHandler : AudioTemplate
{
    public static AmbianceHandler instance;

    // array that holds the ambiance files
    [SerializeField]
    new Audio[] audio = null;

    void Start()
    {
        // loop through the ambiance array and bind it
        for (int i = 0; i < audio.Length; i++)
        {
            GameObject bindAudio = new GameObject("Sound_"+i+"_"+audio[i].fileName);
            bindAudio.transform.SetParent(this.transform);
            audio[i].SetSource(bindAudio.AddComponent<AudioSource>());
        }

        // ambiance to call from start
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

    // ambiance should always loop
    public override void LoopAudio(int index)
    {
        if (!audio[index].loop)
            audio[index].loop = true;
    }

    // random pitch system for ambiance
    public override float PitchAudio()
    {
        return Random.Range(0.7F, 1.3F);
    }

    // play ambiance based on name
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

    public void InitAudio()
    {
        PlayAudio("ocean waves");
    }
}