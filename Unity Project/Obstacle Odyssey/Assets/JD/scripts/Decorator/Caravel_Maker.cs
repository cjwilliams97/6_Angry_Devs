using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * Test template for a Caravel maker script
 * 
 *  utilizing the wrapper method, attributes or perks can be added to visually update the ship 
 */

public class Caravel_Maker : MonoBehaviour
{
    // Start is called before the first frame update

    private bool PlatingState = false;
    private bool SailsState = false;
    private bool LanternState = false;

    void Start()
    {
        CaravelInterface Ship = new PlainShip();    //using decorator, basic concrete plain ship component
        Debug.Log("Caravel maker here: reading from perks and setting components");
        SetPerks();
        SetComponents(Ship);
        //float HP = ChangeHP(PlatingState);
        return;
    }

    void SetComponents(CaravelInterface Ship)
    {
        if (PlatingState)
        {
            Ship = new Caravel_Plating(Ship);
           // GetComponent<Health>().MaxHealthChange(150f);
        }

        if (SailsState)
        {
            Ship = new Caravel_Sails(Ship);
        }

        if (LanternState)
        {
            Ship = new Caravel_Lantern(Ship);
        }

        return;
    }

    void SetPerks()
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
                Debug.Log("ファイルから読んでいます!");
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
    /*
    float ChangeHP(bool state)
    {
        if(state)
        {
            return 100f + 50f;
        }
        else
        {
            return 100f;
        }
    }
    */
}
