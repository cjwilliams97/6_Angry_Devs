using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio
{
    private AudioSource source;

    // allow public changing of filename, clip, volume, and looping
    public string fileName;
    public AudioClip clip;
    public float volume;
    public bool loop = false;
    public float pitch = 1.0F;

    // set the source of the audio
    public void SetSource(AudioSource aSource)
    {
        source = aSource;
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.pitch = pitch;
    }

    // play source
    public void Play()
    {
        source.Play();
    }

    // returns true if the source is playing
    public bool isPlaying()
    {
        return source.isPlaying;
    }
}

// abstract class to handle audio
// TEMPLATE PATTERN
public abstract class AudioTemplate : MonoBehaviour
{ 
    public void GenericAudio(string name)
    {
        PlayAudio(name);
    }
    
    // template loop is off
    public virtual void LoopAudio(int index)
    {
        /*if (audio[index].loop)
            audio[index].loop = false;*/
    }

    // template pitch is unchanged
    public virtual float PitchAudio()
    {
        return 1.0F;
    }

    // template audio playing
    public virtual void PlayAudio(string name)
    {
        /*for (int i = 0; i < audio.Length; i++)
        {
            // find matching audio file and apply template
            if (name == audio[i].fileName)
            {
                LoopAudio(i);
                PitchAudio();
                audio[i].Play();
                return;
            }
        }*/
    }
}