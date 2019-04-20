using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioStressTest : MonoBehaviour
{
    // bind audio
    TestAudioHandler audioHandler;
    public Text audioName;
    public Text audioAmount;
    public Text audioStatus;
    private IEnumerator coroutine;
    private bool CoroutineStarted;

    void Start()
    {
        audioHandler = TestAudioHandler.instance;
        StartCoroutine(AudioTester());
        coroutine = WaitAndChangeScene(5.0f);
    }

    private IEnumerator AudioTester()
    {
        bool done = false;
        float seconds = 1;
        int amt = audioHandler.AudioAmount();
        int count = 0;

        while (!done)
        {
            // loop through the audio array
            for (int i = 0; i < amt; i++)
            {
                // set the UI
                audioName.text = "Audio file: " + audioHandler.CurrPlaying(i);

                // play the next file
                audioHandler.TestAudio(i);
            
                // failure case
                if (!audioHandler.checkPlaying(i))
                {
                    audioStatus.color = Color.red;
                    audioStatus.text = "Test Status: Failure";
                    done = true;   
                    break;
                }
                else
                    audioAmount.text = "Files played without failure: " + count++;

                // success case
                if (count > 200)
                {
                    audioStatus.color = Color.green;
                    audioStatus.text = "Test Status: Success";
                    done = true;
                    break;    
                }

                // wait to play next clip
                yield return new WaitForSeconds(seconds);
            }
            // cut the wait time in half
            seconds = seconds/2;
        }
        StartCoroutine(coroutine);
    }

    // stress test end, return to scene
    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}