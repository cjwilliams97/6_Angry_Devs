using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioHandler : MonoBehaviour
{
    public static TestAudioHandler instance;

    // array that holds the audio files
    [SerializeField]
    new Audio[] audio = null;

    void Start()
    {
        // loop through the audio array and bind it
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

    // play audio based on index
    public void TestAudio(int i)
    {
        audio[i].Play();
        return;
    }

    // returns true if the file is playing
    public bool checkPlaying(int i)
    {
        return audio[i].isPlaying();
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