using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCask : MonoBehaviour
{
    Renderer rend;

    GameObject PARENT;
    GameObject barrel;

    Material newMat;
    Material oldMat;

    Material red;
    Material cream;
    Material grey;

    static float threshold = 20;
    float dist = threshold + 5;
    void Start()
    {
        rend = GetComponent<Renderer>();

        newMat = Resources.Load("JD/Barrels/Materials/BARREL_RED", typeof(Material)) as Material;
        oldMat = Resources.Load("JD/Barrels/Materials/casket_atlas", typeof(Material)) as Material;

        red = Resources.Load("JD/Barrels/red", typeof(Material)) as Material;
        cream = Resources.Load("JD/Barrels/cream", typeof(Material)) as Material;
        grey = Resources.Load("JD/Barrels/grey", typeof(Material)) as Material;

        try
        { PARENT = GameObject.Find("caravel"); }
        catch
        {  Debug.Log("Could not find caravel game object"); }
        barrel = this.gameObject;

        Material[] newMatArray = { newMat, newMat, newMat };
        Material[] oldMatArray = { grey, red, cream };
        StartCoroutine(FlashyFlash(newMatArray, oldMatArray));
    }

    // Update is called once per frame
    bool flag = false;
    void FixedUpdate()
    {
        dist = CalcDist(PARENT, barrel);
        Debug.Log("Distance: " + dist);
        if (dist <= threshold)
        {
            if(dist <= (threshold / 3))
            {
                ExplodeCask(barrel, flag);
                flag = true;
            }
        }
        return;
    }
  
    IEnumerator FlashyFlash(Material[] newMatArray, Material[] oldMatArray)
    {
        for (; ;)
        {
            if (dist > threshold)
            {
                if(rend.materials != oldMatArray)
                {
                    rend.materials = oldMatArray;
                }
                yield return null;
            }
            else
            {
                rend.materials = newMatArray;
                float waitTime = 0.3f;
                Wait(waitTime);
                rend.materials = oldMatArray;
                Wait(waitTime);
            }
        }
    }

    //WIP, currently spawns in bunches of explosions if not destroyed, we want one and wait
    public GameObject ExplodeyPrefab;
    void ExplodeCask(GameObject barrel, bool flag)
    {
        if (flag)
        {
            return;
        }
        else
        {
            Debug.Log("BARREL TO BE EXPLODED!");
            /*
            Instantiate(ExplodeyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Wait(4f);
            Destroy(barrel);
            */
            return;
        }
    }

    void Wait(float time)
    {
        StartCoroutine(WaitFor(time));
        return;
    }

    IEnumerator WaitFor(float time)
    {
        yield return new WaitForSeconds(time);
    }

    float CalcDist(GameObject PARENT, GameObject barrel)
    {
        //return sqrt( (x2 - x1 )^2 - (y2 - y1)^2 )
        //return Mathf.Sqrt(Mathf.Pow((PARENT.transform.position.x - barrel.transform.position.x), 2) - Mathf.Pow((PARENT.transform.position.z - barrel.transform.position.z), 2));
        return Vector3.Distance(PARENT.transform.position, barrel.transform.position);
    }
}
