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

        newMat = Resources.Load("JD/Barrels/Materials/BARREL_RED", typeof(Material)) as Material;   //new barrel material
        oldMat = Resources.Load("JD/Barrels/Materials/casket_atlas", typeof(Material)) as Material; //old barrel material (legacy)
    
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
    void FixedUpdate()
    {
        dist = CalcDist(PARENT, barrel);
        Debug.Log("Distance: " + dist);
        if (dist <= threshold)
        {
            if(dist <= (threshold / 3))
            {
                ExplodeCask(barrel);
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
                if(rend.materials != oldMatArray)   //resets materials array to old materials and returns
                {
                    rend.materials = oldMatArray;
                }
                yield return null;
            }
            else
            {
                rend.materials = newMatArray;       //set materials to a new red / orange color and flash back and forth
                float waitTime = 0.3f;
                yield return new WaitForSeconds(waitTime);
                rend.materials = oldMatArray;
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
    //WIP, currently spawns in bunches of explosions if not destroyed, we want one and wait
    public GameObject ExplodeyPrefab;
    int count = 0;
    void ExplodeCask(GameObject barrel)
    {
        Debug.Log("BARREL TO BE EXPLODED!");
        count++;
        if(count == 1)  //ensures that it only instantiates a single instance of the explosion prefab
        {
            Instantiate(ExplodeyPrefab, new Vector3(barrel.transform.position.x, barrel.transform.position.y, barrel.transform.position.z), Quaternion.identity);
        }
        else
        {
            Destroy(barrel);    //destroys barrel gameobject along with its child scripts / componenets
        }
        return;
    }

    float CalcDist(GameObject PARENT, GameObject barrel)
    {
        //return sqrt( (x2 - x1 )^2 - (y2 - y1)^2 )
        //return Mathf.Sqrt(Mathf.Pow((PARENT.transform.position.x - barrel.transform.position.x), 2) - Mathf.Pow((PARENT.transform.position.z - barrel.transform.position.z), 2));
        return Vector3.Distance(PARENT.transform.position, barrel.transform.position);
    }
}
