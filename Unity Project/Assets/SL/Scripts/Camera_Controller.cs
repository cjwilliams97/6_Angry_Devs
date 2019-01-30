using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehavior{
    //Camera must not have any parents
    public transform target;
    //this is the player object that will be the target

    [Range(0,1)]
    public float smooth = 1f;

    Vector3 offset;
    
    public bool isLocked = false;

    void start(){
        offset = tranform.localPosition - target.localPosition;
        isLocked = true;
    }

    void FixedUpdate(){
        if(isLocked){
            Vector3 CamTarget = target.localPosition + offset;

            tranform.positon = Vector3.Lerp(transform.position,CamTarget,smoothing);
        }
    }
}