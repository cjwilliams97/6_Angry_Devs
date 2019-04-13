using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioStressTest : MonoBehaviour
{
    // bind audio
    AudioHandler audioHandler;
    public Text audioName;
    public Text audioAmount;
    public Text audioStatus;
    private IEnumerator coroutine;
    private bool CoroutineStarted;

    void Start()
    {
        audioHandler = AudioHandler.instance;
        StartCoroutine(AudioTester());
        coroutine = WaitAndChangeScene(5.0f);
    }

    private IEnumerator AudioTester()
    {
        bool done = false;
        bool failure = false;
        float seconds = 2;
        int amt = audioHandler.AudioAmount();
        int count = 0;

        while(!done)
        {
            // loop through the audio array
            for(int i = 0; i < amt; i++)
            {
                // play the next file in the array
                audioHandler.TestAudio(i);
                audioName.text = "Audio file: " + audioHandler.CurrPlaying(i);
                audioAmount.text = "Files played without failure: " + count++;

                // wait to play next clip
                yield return new WaitForSeconds(seconds);
                if(count > 300)
                {
                    // success case
                    if(!failure)
                    {
                        audioStatus.color = Color.green;
                        audioStatus.text = "Test Status: Success";
                    }
                    // failure case
                    else
                    {
                        audioStatus.color = Color.red;
                        audioStatus.text = "Test Status: Failure";
                    }
                    done = true;
                }
            }
            // cut the wait time in half
            seconds = seconds/2;
        }
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("JubalTest", LoadSceneMode.Single);
    }
}