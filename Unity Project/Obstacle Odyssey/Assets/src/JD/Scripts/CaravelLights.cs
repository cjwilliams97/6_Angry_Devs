using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravelLights : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject PARENT;
    GameObject FrontLantern;
    GameObject BacklanternL;
    GameObject BackLanternR;
    void Awake()
    {
        PARENT = GameObject.Find("Caravel");
        FrontLantern = GameObject.Find("FrontLantern");
        BacklanternL = GameObject.Find("BacklanternL");
        BackLanternR = GameObject.Find("BackLanternR");

        FrontLantern.transform.position = PARENT.transform.position;
        FrontLantern.transform.localScale = PARENT.transform.lossyScale;
        FrontLantern.transform.SetParent(PARENT.transform);
        FrontLantern.transform.localPosition += new Vector3(0.065f, 0.001f, 0.02f);

        BacklanternL.transform.position = PARENT.transform.position;
        BacklanternL.transform.localScale = PARENT.transform.lossyScale;
        BacklanternL.transform.SetParent(PARENT.transform);
        BacklanternL.transform.localPosition += new Vector3(-0.050f, -0.00777f, 0.022f);

        BackLanternR.transform.position = PARENT.transform.position;
        BackLanternR.transform.localScale = PARENT.transform.lossyScale;
        BackLanternR.transform.SetParent(PARENT.transform);
        BackLanternR.transform.localPosition += new Vector3(-0.050f, 0.01f, 0.022f);
    }  
}
