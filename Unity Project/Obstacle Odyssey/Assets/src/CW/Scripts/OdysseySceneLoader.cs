/* 
 * Implements loading scene using an Async Operation.
 * LoadScene() is called by the LobbyMenuControl script
 * Created by Connor Williams 4/16/19
 * Last modified by Connor Williams 4/16/19
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OdysseySceneLoader : MonoBehaviour
{
    private bool CurrentlyLoadingScene = false;
    public Text LoadingText;
    public GameObject LoadingTextObj;
    public GameObject LoadingImageObj;
    public GameObject LoadingScreenObj;
    public string DesiredMap;

    // Update is called once per frame
    void Update()
    {
       if (CurrentlyLoadingScene == true)
        {
            LoadingImageObj.SetActive(true);
            LoadingTextObj.SetActive(true);
            LoadingText.color = new Color(LoadingText.color.r, LoadingText.color.g, LoadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
        else
        {
            LoadingImageObj.SetActive(false);
            LoadingTextObj.SetActive(false);
        }
    }
    /* Loads the desired scene using an Async Operation */
    public void LoadScene()
    {
        CurrentlyLoadingScene = true;
        StartCoroutine(LoadSceneAsync());
    }
    IEnumerator LoadSceneAsync() //Async Operation
    {
        yield return new WaitForSeconds(3);

        //AsyncOperation async = Application.LoadLevelAsync(DesiredMap);
        AsyncOperation async = SceneManager.LoadSceneAsync(DesiredMap);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
