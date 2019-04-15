using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * The main powerhouse for the Perk System in Obstacle Odyssey. This script handles UI management which in turn
 * implements and utlizes both the decorator and memento pattern. Perk values are written to a file
 * store on the Applications persistant datapath.
 * A brief description of how each pattern is 
 * implemented is as follows:
     * Decorator:
     *  Ship Perks are instantiated at runTime and utilize a decorator pattern to selectively wrap components around
     *  a concrete PlainShip component
     * Memento:
     *  The memento pattern is utilized with the Undo button that, when pressed, restores the Caravel's attributes
     *  to its recalled state when first opening the Perk system
 */
public class ButtonManager : MonoBehaviour
{
    GameObject AddButton, RemoveButton, UndoButton, DoneButton; //UI button game objects
    List<Perk> PerkList = new List<Perk>(); //List of Perk class items
    CaravelInterface Ship;  //decorator pattern interface
    Originator Origin;  //memento pattern orignanotor
    Caretaker BabySitter;   //memento pattern caretaker
    void Start()
    {
        Ship = new PlainShip();
        Origin = new Originator();

        //--    Initialize buttons, listeners, and the perk items, perk toggle states, set onscreen toggles to false
        InitializeButtons();
        InitializeButtonListeners();
        InitializePerkListItems();
        InitilizeStates(); 
        SetTogglesFalse();

        //--       Set the Originator's states to the current states read from file, create a memento of these states if user wishes to undo
        Origin.State = (GenerateStateString());
        BabySitter = new Caretaker();
        BabySitter.Memento = Origin.CreateMemento();
    }

    void InitializePerkListItems()
    {
        //template for adding a Perk (assumption that perk is created properly and has corresponding models at proper locations
        /*
        Perk test = new Perk(); //perk
        test.state = false;     //perk's toggle state
        test.ToggleName = "test";   //perks toggle name
        test._DName = "test(Clone)";    //gameobject for respective perk for Destroy()
        test.Object = GameObject.Find(test.ToggleName); //finds gameobject of ToggleName
        PerkList.Add(test); //adds perk to perklist
        */

        Perk Plating = new Perk();
        Plating.state = false;
        Plating.ToggleName = "PlatingToggle";
        Plating.Object = GameObject.Find(Plating.ToggleName);
        Plating._DName = "caravel_plating(Clone)";
        PerkList.Add(Plating);

        Perk Sails = new Perk();
        Sails.state = false;
        Sails.ToggleName = "SailsToggle";
        Sails.Object = GameObject.Find(Sails.ToggleName);
        Sails._DName = "caravel_sails(Clone)";
        PerkList.Add(Sails);

        Perk Lantern = new Perk();
        Lantern.state = false;
        Lantern.ToggleName = "LanternToggle";
        Lantern.Object = GameObject.Find(Lantern.ToggleName);
        Lantern._DName = "caravel_lanterns(Clone)";
        PerkList.Add(Lantern);

        return;
    }

    //add button listener
    void AddButtonClicked()
    {
        Debug.Log("You have clicked the Add button!");
        AddShipAttributes();

        //update Originator states
        Origin.State = (GenerateStateString());
        SetTogglesFalse();
        return;
    }

    void AddShipAttributes()
    {
        foreach(Perk p in PerkList)
        {
            if(p.Object.GetComponent<Toggle>().isOn)
            {
                if(p.state != true)
                {
                    AddAttribute(p);
                }
                p.state = true;
            }
        }
        return;
    }

    //Attributes and their corresponding decorator functions
    void AddAttribute(Perk p)
    {
        switch (p.ToggleName)
        {
            case "PlatingToggle":
                Ship = new Caravel_Plating(Ship);
                break;
            case "SailsToggle":
                Ship = new Caravel_Sails(Ship);
                break;
            case "LanternToggle":
                Ship = new Caravel_Lantern(Ship);
                break;
            default:
                Debug.Log("Unknown perk request");
                break;
        }
        return;
    }

        //remove button listener
    void RemoveButtonClicked()
    {
        Debug.Log("You have clicked the Remove button!");
        DestroyShipAttributes();

        Origin.State = (GenerateStateString()); //update Origonator states
        SetTogglesFalse();
        return;
    }
        
    //try to destroy each perk flagged for removal
    void DestroyShipAttributes()
    {
        foreach(Perk p in PerkList)
        {
            if(p.Object.GetComponent<Toggle>().isOn)
            {
                try
                {
                    Destroy(GameObject.Find(p._DName));
                    Debug.Log("Destroying: "+p._DName);
                }
                catch { }
                p.state = false;
            }
        }
        return;
    }

    //undo button listener
    void UndoButtonClicked()
    {
        Debug.Log("You have clicked the Undo button!");
        Origin.SetMemento(BabySitter.Memento);  //recall Memento states

        string states = Origin.State;
        GenerateStateString(states);    //given a string of states, updates perk state bools
        RestoreAttributes();
        return;
    }

    //restore caravel attribute instantiation to memento state
    void RestoreAttributes()
    {
        foreach(Perk p in PerkList)
        {
            if(p.state)
            {
                if(!GameObject.Find(p._DName))
                {
                    AddAttribute(p);
                }
                p.state = true;
            }
            else
            {
                try
                {
                    Destroy(GameObject.Find(p._DName));
                    Debug.Log("Destroying: " + p._DName);
                }
                catch { }
                p.state = false;
            }

        }
        return;
    }
    //done button listener
    void DoneButtonClicked()
    {
        Debug.Log("You have clicked the Done button!");
        WritePerksToFile();
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);  //load back to the main menu
        return;
    }

    void WritePerksToFile()
    {
        string fileName = "Perks.txt";
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (!File.Exists(path))
        {
            Debug.Log("Creating file");
            File.Create(path);
        }
        //Write 1 or 0 state for each perk to the perks file path for reading in other scripts
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
        {
            Debug.Log("Writing to file!");
            Debug.Log(path);

            foreach(Perk p in PerkList)
            {
                if(p.state)
                {
                    file.WriteLine("1");
                }
                else
                {
                    file.WriteLine("0");
                }
            }
        }
        return;
    }

    //used for generating the state string utilized by the memento pattern
    string GenerateStateString()
    {
        string statesString = "";
        foreach(Perk p in PerkList)
        {
            if(p.state)
            {
                statesString += "1";
            }
            else
            {
                statesString += "0";
            }
        }
        return statesString;
    }

    //given a string of states, generates global bools from statestring
    void GenerateStateString(string states)
    {
        int i = 0;
        foreach(char c in states)
        {
            if(c == '1')
            {
                PerkList[i].state = true;
            }
            else
            {
                PerkList[i].state = false;
            }
            i++;
        }    
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

    void SetTogglesFalse()
    {
        foreach (Perk p in PerkList)
        {
            p.Object.GetComponent<Toggle>().isOn = false;
        }
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
                Debug.Log("Reading states from Perks file。");
                Debug.Log(path);
                string line = "";
                int i = 0;
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "1")
                    {
                        PerkList[i].state = true;
                    }
                    else
                    {
                        PerkList[i].state = false;
                    }
                    i++;
                }
            }
        }
        return;
    }
}
