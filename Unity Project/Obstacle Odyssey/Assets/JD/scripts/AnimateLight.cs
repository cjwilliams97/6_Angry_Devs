using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLight : MonoBehaviour
{
   //light gameobjects
    GameObject Forgelight;
    GameObject RimLight;
    GameObject AnvilLight;
    GameObject PedastalLight;

    float t = 0; float duration = 2.0f;
    void Start()
    {
        //finds all light gameobjects to move in the forge
        Forgelight = GameObject.Find("forgelight");
        RimLight = GameObject.Find("rimlight");
        AnvilLight = GameObject.Find("anvillight");
        PedastalLight = GameObject.Find("pedastallight");
    }

    // Update is called once per frame
    void Update()
    {
        float pastt = t;
        t = (Mathf.PingPong(Time.time, duration) / duration);
        MoveLight(Forgelight, t, pastt, 0.001f);
        MoveLight(RimLight, t, pastt, 0.01f);
        MoveLight(AnvilLight, t, pastt, 0.001f);
        MoveLight(PedastalLight, t, pastt, 0.001f);
    }

    void MoveLight(GameObject Obj, float pastt, float t, float Scalor)
    {
        if (t - pastt >= 0) //positive translation case
            Obj.transform.Translate(0, t * Scalor, 0);
        else    //negative translation case
            Obj.transform.Translate(0, -(t * Scalor), 0);
        return;
    }
}
