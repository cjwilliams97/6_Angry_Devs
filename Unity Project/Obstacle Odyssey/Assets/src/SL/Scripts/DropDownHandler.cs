//THIS IS THE LIST OF ALL SELECTABLE MAPS AND THE HANDLER FOR RETURNING THE DESIRED MAP
//If you edit this list, it will break stuff unlesss you know what you are doing
//each element in list is indexed from 0 starting at the first item in the list!


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropDownHandler : MonoBehaviour
{
    List<string> Maps = new List<string> { "Oasis","Spooki nights"};
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
    //0 = Oasis Map

    /* Every Frame, looks for selected dropdown value, declares the string to be the string that is the desired map */
    void Update()
    {

        if (drop.value == 0)
        {
            DesiredSceneString = "BFGameLevel";
            //Debug.Log("Desired Scene set to BFGameLevel");
        }
        if(drop.value == 1)
        {
            DesiredSceneString = "JDLevel";
        }
        





    }

    //Returns the currently selected map, used by the lobby play button.
    public string RequestMap()
    {
        return DesiredSceneString;
    }
}
