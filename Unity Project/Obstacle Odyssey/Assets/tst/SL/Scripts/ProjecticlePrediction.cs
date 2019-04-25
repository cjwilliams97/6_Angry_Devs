using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecticlePrediction : MonoBehaviour
{
    public float speed = 420.0f;
    public int predictionStepsPerFrame = 6;
    public Vector3 BallVelocity;
    public GameObject firepoint;
    void Start()
    {
        BallVelocity = new Vector3(7.2f, 0f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point1 = this.transform.position;
        float stepSize = 1.0f / predictionStepsPerFrame;
        for( float step = 0; step < 1; step += stepSize)
        {
            BallVelocity += Physics.gravity * stepSize * Time.deltaTime;
            Vector3 point2 = point1 + BallVelocity * stepSize * Time.deltaTime;

            Ray ray = new Ray(point1, point2 - point1);
            if (Physics.Raycast(ray, (point2 - point1).magnitude))
            {
                Debug.Log("Hit");
            }
            
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 point1 = this.transform.position;
        Vector3 PredictedBallVelocity = BallVelocity;
        float stepSize = .01f;
        for (float step = 0 ; step < 1; step+= stepSize)
        {
            PredictedBallVelocity += Physics.gravity * stepSize * Time.deltaTime;
            Vector3 point2 = point1 + PredictedBallVelocity * stepSize;
            Gizmos.DrawLine(point1, point2);
            point1 = point2;
        }

    }
}
