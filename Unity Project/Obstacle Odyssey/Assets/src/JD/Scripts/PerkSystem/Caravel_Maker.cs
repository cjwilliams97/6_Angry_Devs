using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/*
 * Test template for a Caravel maker script
 *  utilizing the wrapper method, attributes or perks can be added to visually update the ship 
 */

public class Caravel_Maker : MonoBehaviour
{
    // Start is called before the first frame update

    List<Perk> PerkList = new List<Perk>(); //List of Perk class items
    CaravelInterface Ship;  //decorator pattern interface
    void Awake()
    {
        Ship = new PlainShip();    //using decorator, basic concrete plain ship component
        Debug.Log("Caravel maker here: reading from perks and setting components");
        InitializePerkListItems();
        InitilizeStates();
        SetComponents(Ship);
        return;
    }

    void SetComponents(CaravelInterface Ship)
    {
        foreach(Perk p in PerkList)
        {
            if (p.state)
            {
                AddAttribute(p);
            }
        }
        return;
    }

    /*
    //Currently Redacted, changing functionality of ship adds unfoseen issues, WIP
    void AddFunctionality()
    {
        foreach (Perk p in PerkList)
        {
            if (p.state)
            {
                AddFunction(p);
            }
        }
        return;
    }

    void AddFunction(Perk p)
    {
        switch (p.ToggleName)
        {
            case "PlatingToggle":
                Debug.Log("Adding bonus HP");
                GetComponent<Health>().MaxHealthChange(150f);
                break;
            case "SailsToggle":
                Debug.Log("Increasing Engine Power");
                //
                break;
            case "LanternToggle":
                //
                break;
            default:
                Debug.Log("Unknown perk request");
                break;
        }
        return;
    }
    */
    //Attributes and their corresponding decorator functions
    void AddAttribute(Perk p)
    {
        switch (p.ToggleName)
        {
            case "PlatingToggle":
                Debug.Log("CM: Adding Plating");
                Ship = new Caravel_Plating(Ship);
                break;
            case "SailsToggle":
                Debug.Log("CM: Adding Sails");
                Ship = new Caravel_Sails(Ship);
                break;
            case "LanternToggle":
                Debug.Log("CM: Adding Lantern");
                Ship = new Caravel_Lantern(Ship);
                break;
            default:
                Debug.Log("Unknown perk request");
                break;
        }
        return;
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
                    i++;
                }
            }
        }
        return;
    }

}


