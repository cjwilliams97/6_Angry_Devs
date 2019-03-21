﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModelStressTest : MonoBehaviour
{
    GameObject Whale;
    const int K = 3;
    string FPSTEXT = string.Format("UNITIALIZED\n");
    string MODELTEXT = string.Format("MODEL TEST TBA\n");
    string SMOKETEXT = string.Format("SMOKE TEST TBA\n");

    bool inFirst = false;
    bool inSecond = false;
    bool StartSkip = true;
    bool Failed = false;

    int FrameCounter = 0;
    void Start()
    {
        Whale = Resources.Load("JD/Whale/Whale") as GameObject; //uses whale.fbx gameobject (unimportant) for mass instantiations
        int amount = 1000;
        StartModelTest(amount); //starts model stress test
        StartSmokeTest(amount); //starts smoke stress test

        StartCoroutine(DoLast());
        return;
    }

    private IEnumerator DoLast()
    {
        while(inFirst || inSecond)
            yield return new WaitForSeconds(0.1f);


        yield return new WaitForSeconds(5.0f);
        Debug.Log("Tests Complete");

        if (Failed)
            Debug.Log(": FAILURE");
        else
            Debug.Log(": SUCCESS");

        //Tests are complete, load back to the main menu scene.
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        yield break;
    }

    //smoke stress test wrapper function
    void StartSmokeTest(int amount) 
    {
        StartCoroutine(SmokeTest(amount));
        return;
    }

    public GameObject myPrefab = null;
    private IEnumerator SmokeTest(int n)
    {
        inSecond = true;
        int amount = n / 50;
        GameObject[] Objects = new GameObject[amount];
        yield return new WaitForSeconds(10);

        for(int i = 0; i < amount; i++)
        {
            Objects[i] = Instantiate(myPrefab, transform.position, transform.rotation, this.transform);
            SMOKETEXT = string.Format($"SMOKE TEST:\nAMOUNT: {amount}\nINSTANTIATED:{i + 1}\n");    //updates Smoke test GUI text
            yield return new WaitForSeconds(1.0f);  //delays instantiation of new smoke objects for smoother observation
        }

        //Insantiation of smoke generation prefabs complete
        SMOKETEXT = string.Format($"SMOKE TEST:\nInstatiation Complete: Deleting\n");
        for(int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.25f); //delays destruction of smoke systems for smoother observation
            Destroy(Objects[i]);
        }
        SMOKETEXT = string.Format($"SMOKE TEST:\nDeletion Complete\n");
        inSecond = false;
        yield break;
    }

    //Model stress test wrapper function
    void StartModelTest(int amount) 
    {
        GameObject[] Objects = new GameObject[amount];
        StartCoroutine(GenerateModels(Objects,amount));
        return;
    }

    private IEnumerator GenerateModels(GameObject[] Objects, int amount)
    {
        yield return new WaitForSeconds(5);
        inFirst = true;
        Vector3 position;
        for (int i = 0; i < amount; i++)
        {
            position = new Vector3(i + K, (i % 10) + K, (i % 10) + K);
            Objects[i] = Instantiate(Whale, transform.position, Quaternion.identity, this.transform) as GameObject;
            Objects[i].transform.position += position;
            transform.Translate(Vector3.left * Time.deltaTime * (K * 2));
            MODELTEXT = string.Format($"MODEL TEST:\nAMOUNT: {amount}\nINSTANTIATED:{i + 1}\n");//updates model test GUI text
            yield return null;
        }

        //Insantiation of models complete
        MODELTEXT = string.Format($"MODEL TEST:\nInstatiation Complete: Deleting\n");
        for (int i = 0; i < amount; i++)
            Destroy(Objects[i]);
        MODELTEXT = string.Format($"MODEL TEST:\nDeletion Complete\n");
        inFirst = false;
        yield break;
    }

    float deltaTime = 0.0f;
    void Update()
    {
        if (StartSkip == false)
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        else
        {
            FrameCounter++;
            if (FrameCounter >= 10)
                StartSkip = false;
        }
    }

    void OnGUI()
    {
        int w = Screen.width;
        int h = Screen.height;
        Rect FPSRect = new Rect(10, 10, w, h * 2 / 50);
        Rect MODELRect = new Rect(10, 30, w, h * 2 / 50);
        Rect SMOKERect = new Rect(10, 120, w, h * 2 / 50);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        FPSTEXT = string.Format("CURRENT FPS: {0:0.0} ms ({1:0.} fps)", msec, fps);

        if(fps < 5.0f)
        {
            //FAILURE STATE
            style.normal.textColor = Color.red;
            Debug.Log("FPS below 5. Failure state Incurred.");
            inFirst = false;
            inSecond = false;
            Failed = true;
        }
        else if (fps < 15.0f)
        {
            style.normal.textColor = Color.yellow;
            //FPS pretty low
            Debug.Log("FPS below 15.");
        }
        else if (fps < 30.0f)
        {
            style.normal.textColor = Color.blue;
            //FPS low but in acceptable rates
            Debug.Log("FPS below 30.");
        }
        else
        {
            style.normal.textColor = Color.black;
        }

        GUI.Label(FPSRect, FPSTEXT, style);
        GUI.Label(MODELRect, MODELTEXT, style);
        GUI.Label(SMOKERect, SMOKETEXT, style);
    }
}