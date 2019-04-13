using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoat : MonoBehaviour
{
    void Start()
    {
        InitializeBoat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeBoat()
    {
        GameObject Base = Instantiate(Resources.Load("JD/Caravel/caravel_base", typeof(GameObject))) as GameObject;
        GameObject Sails = Instantiate(Resources.Load("JD/Caravel/caravel_sails", typeof(GameObject))) as GameObject;
        GameObject Wheel = Instantiate(Resources.Load("JD/Caravel/caravel_wheel", typeof(GameObject))) as GameObject;
        GameObject Rudder = Instantiate(Resources.Load("JD/Caravel/caravel_rudder", typeof(GameObject))) as GameObject;
        Base.transform.parent = this.transform;
        Sails.transform.parent = Base.transform;
        Wheel.transform.parent = Base.transform;
        Rudder.transform.parent = Base.transform;

        Texture Caravel_Texture = Resources.Load<Texture>("JD/Caravel/caravel_atlas");
        Base.gameObject.GetComponent<Renderer>().material.mainTexture = Caravel_Texture;
        Sails.gameObject.GetComponent<Renderer>().material.mainTexture = Caravel_Texture;
        Wheel.gameObject.GetComponent<Renderer>().material.mainTexture = Caravel_Texture;
        Rudder.gameObject.GetComponent<Renderer>().material.mainTexture = Caravel_Texture;
        return;
    }
}
