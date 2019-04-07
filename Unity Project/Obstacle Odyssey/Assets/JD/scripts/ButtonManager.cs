using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
   //UI button game objects
    GameObject AddButton, RemoveButton, UndoButton, DoneButton;

    //perk toggle game objects
    GameObject PlatingToggle;
    GameObject SailsToggle;
    GameObject LanternToggle;

    //perk states
    bool PlatingState = false;
    bool SailsState = false;
    bool LanternState = false;

    CaravelInterface Ship;

    void Start()
    {
        Ship = new PlainShip();

        //--    Initialize buttons, listeners, and the perk toggles
        InitilizeStates();
        InitializeButtons();
        InitializeButtonListeners();
        InitializePerks();   
    }
   
    //add button listener
    void AddButtonClicked()
    {
        Debug.Log("You have clicked the Add button!");
        //--    Set bool states to current state of the UI toggles
        if (PlatingToggle.GetComponent<Toggle>().isOn && PlatingState!= true)
        {
            PlatingState = true;
            Ship = new Caravel_Plating(Ship);
        }
        if (SailsToggle.GetComponent<Toggle>().isOn && SailsState != true)
        {
            SailsState = true;
            Ship = new Caravel_Sails(Ship);
        }
        if (LanternToggle.GetComponent<Toggle>().isOn && LanternState != true)
        {
            LanternState = true;
            Ship = new Caravel_Lantern(Ship);
        }

        //create a memento here?

        SetTogglesFalse();
        return;
    }

    //remove button listener
    void RemoveButtonClicked()
    {
        Debug.Log("You have clicked the Remove button!");

        //destroys selected objects (currently sketch way to do it, fix this)
        if (PlatingToggle.GetComponent<Toggle>().isOn)
        {
            Debug.Log("Destroying Plates!");
            Destroy(GameObject.Find("caravel_plating(Clone)"));
            PlatingState = false;
        }
        if (SailsToggle.GetComponent<Toggle>().isOn)
        {
            Debug.Log("Destroying Sails!");
            Destroy(GameObject.Find("caravel_sails(Clone)"));
            SailsState = false;
        }
        if (LanternToggle.GetComponent<Toggle>().isOn)
        {
            Debug.Log("Destroying Lanterns!");
            Destroy(GameObject.Find("caravel_lanterns(Clone)"));
            LanternState = false;
        }

        //create a memento here

        SetTogglesFalse();
        return;
    }

    //undo button listener
    void UndoButtonClicked()
    {

        //WIP: here goes the memento thingy
        Debug.Log("You have clicked the Undo button!");
        return;
    }

    //done button listener
    void DoneButtonClicked()
    {
        Debug.Log("You have clicked the Done button!");
        string fileName = "Perks.txt";
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if(!File.Exists(path))
        {
            Debug.Log("Creating file");
            File.Create(path);
        }
        //Write 1 or 0 state for each perk to the perks file path for reading in other scripts
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
        {
            Debug.Log("Writing to file!");
            Debug.Log(path);

            if (PlatingState)
                file.WriteLine("1");
            else
                file.WriteLine("0");

            if (SailsState)
                file.WriteLine("1");
            else
                file.WriteLine("0");

            if (LanternState)
                file.WriteLine("1");
            else
                file.WriteLine("0");
        }
            return;
    }

    //finds perk toggles respective gameobjects
    void InitializePerks()
    {
        PlatingToggle = GameObject.Find("PlatingToggle");
        SailsToggle = GameObject.Find("SailsToggle");
        LanternToggle = GameObject.Find("LanternToggle");

        SetTogglesFalse();
        return;
    }

    //sets all UI perk toggles to false
    void SetTogglesFalse()
    {
        PlatingToggle.GetComponent<Toggle>().isOn = false;
        SailsToggle.GetComponent<Toggle>().isOn = false;
        LanternToggle.GetComponent<Toggle>().isOn = false;

        return;
    }

    //finds UI buttons respective gameobjects
    void InitializeButtons()
    {
        AddButton = GameObject.Find("AddButton");
        RemoveButton = GameObject.Find("RemoveButton");
        UndoButton = GameObject.Find("UndoButton");
        DoneButton = GameObject.Find("DoneButton");
        return;
    }

    //adds UI buttons respective listeners
    void InitializeButtonListeners()
    {
        AddButton.GetComponent<Button>().onClick.AddListener(AddButtonClicked);
        RemoveButton.GetComponent<Button>().onClick.AddListener(RemoveButtonClicked);
        UndoButton.GetComponent<Button>().onClick.AddListener(UndoButtonClicked);
        DoneButton.GetComponent<Button>().onClick.AddListener(DoneButtonClicked);
        return;
    }

    void InitilizeStates()
    {
        string fileName = "Perks.txt";
        string path = Path.Combine(Application.persistentDataPath, fileName);   //persistant filepath for perk states
        if (!File.Exists(path))
        {
            Debug.Log("Perks File does not exist");
            return;
        }
        else
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                Debug.Log("ファイルから読んでいます。");
                Debug.Log(path);

                string line = file.ReadLine();
                if (line == "1")
                {
                    PlatingState = true;
                }
               
                line = file.ReadLine();
                if (line == "1")
                {
                    SailsState = true;
                }
               
                line = file.ReadLine();
                if (line == "1")
                {
                    LanternState = true;
                }
            }
        }
        return;
    }
}
