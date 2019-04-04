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
    List<string> Maps = new List<string> { "Oasis"  };
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
            DesiredSceneString = "BFGameLevel";
            //Debug.Log("Desired Scene set to BFGameLevel");
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
