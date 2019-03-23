using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropDownHandler : MonoBehaviour
{
    //THIS IS THE LIST OF ALL SELECTABLE MAPS
    //If you edit this list, it will break stuff unlesss you know what you are doing
    //each element in list is indexed from 0 starting at "Gamescene"
    List<string> Maps = new List<string> { "GameScene", "SLFailedTest", "SLSucessTest", "StressTest","JDTest","BrandonTest" };
    private Dropdown drop;
    private Canvas SceneCanvas;
    public Scene DesiredScene;
    public string DesiredSceneString;
    // Start is called before the first frame update
    void Start()
    {
        drop = GetComponent<Dropdown>();
        SceneCanvas = GetComponent<Canvas>();
        drop.ClearOptions();
        drop.AddOptions(Maps);
    }
    
    // Drop.value table
    //0 = GameScene 
    //1 = SLFailedTest
    //2 = SLSucessTest
    //3 = StressTest
    //4 = JDTest
    //5 = BrandonTest

    void Update()
    {
        if (drop.value == 0)
        {
            DesiredSceneString = "GameScene";
            //Debug.Log("Desired Scene set to GameScene");
        }
        else if (drop.value == 1)
        {
            DesiredSceneString = "SLFailedTest";
            //Debug.Log("Desired Scene set to SLFailedTest");
        }
        else if (drop.value == 2)
        {
            DesiredSceneString = "SLSucessTest";
            //Debug.Log("Desired Scene set to SLSucessTest");
        }
        else if (drop.value == 3)
        {
            DesiredSceneString = "StressTest";
            //Debug.Log("Desired Scene set to StressTest");
        }
        else if (drop.value == 4)
        {
            DesiredSceneString = "JDTest";
            //Debug.Log("Desired Scene set to JDTest");
        }
        else if (drop.value == 5)
        {
            DesiredSceneString = "BrandonTest";
            //Debug.Log("Desired Scene set to BrandonTest");
        }
        else if (drop.value == 6)
        {
            DesiredSceneString = "SLFailedTest";
            //Debug.Log("Desired Scene set to SLFailedTest");
        }

    }
    // Drop.value table
    //0 = GameScene
    //1 = Placeholder 1
    //2 =  Placeholder 2
    //3 = Placeholder 3

    //Returns the currently selected map, used by the lobby play button.
    public string RequestMap()
    {
        return DesiredSceneString;
    }
}
