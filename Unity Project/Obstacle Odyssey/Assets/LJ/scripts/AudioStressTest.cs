using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStressTest : MonoBehaviour
{
    // bind audio
    AudioHandler audioHandler;
    void Start()
    {
        audioHandler = AudioHandler.instance;
    }

    void Update()
    {
        audioHandler.TestAudio();
    }
}

