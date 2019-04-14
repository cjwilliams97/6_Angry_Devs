using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio
{
    private AudioSource source;
    public string fileName;
    public AudioClip clip;

    // allow changing of volume, looping, and playing on awake
    public float volume;
    public bool loop = false;
    public bool playOnAwake = false;

    // set the source of the audio
    public void SetSource(AudioSource aSource)
    {
        source = aSource;
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.playOnAwake = playOnAwake;
    }

    // play it
    public void Play()
    {
        source.Play();
    }
}

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance;

    // array that holds the audio files
    [SerializeField]
    new Audio[] audio = null;

    // ensures a single instance on the bound object
    // SINGLETON PATTERN
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        // loop through the audio array and bind it to its respective objects
        for (int i = 0; i < audio.Length; i++) 
        {
            GameObject bindAudio = new GameObject("Sound_"+i+"_"+audio[i].fileName);
            bindAudio.transform.SetParent(this.transform);
            audio[i].SetSource(bindAudio.AddComponent<AudioSource>());
        }

        // audio to play from the start
        PlayAudio("high Cs");
        PlayAudio("ocean");
    }

    public void PlayAudio(string name)
    {
        // loop through audio array
        for (int i = 0; i < audio.Length; i++)
        {
            // find the matching name and play it
            if (audio[i].fileName == name)
            {
                audio[i].Play();
                return;
            }
        }
    }

    // play the clip at specified index
    public void TestAudio(int i)
    {
        audio[i].Play();
        return;
    }

    // returns the audio array size
    public int AudioAmount()
    {
        return audio.Length;
    }

    // returns clip name at specified index
    public string CurrPlaying(int i)
    {
        return audio[i].fileName;
    }

}