using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class ShipReturn : MonoBehaviour
    {
        int counter; // will be used to run update 20 times

        void Start() // consider awake instead
        {
            UpdateBoat();
            counter = 20;
        }

        void Update()
        {
            //Debug.Log("1 - Made it to Update number: " + counter);
            counter--;

            if (counter > 0)
            {
                UpdateBoat();
            }

            else
            {
                enabled = false;
            }
        }

       
        protected enum BoatPosition
        {
            Standard,
            Offset
        }

        BoatPosition initialLocationMode = BoatPosition.Offset; // sets boat to offset state initially

        public virtual void UpdateBoat()
        {
            //Debug.Log("1 - Made it to UpdateBoat");
            float valueX = this.gameObject.transform.position.x;
            float valueY = this.gameObject.transform.position.y;
            float valueZ = this.gameObject.transform.position.z;

            switch (initialLocationMode)
            {
                case BoatPosition.Offset:
                    if (valueX >= 2 || valueY >= 5.5 || valueZ >= 2 || valueX <= -2 
                        || valueY <= 3.5 || valueZ <= -2)
                    {
                        //Debug.Log("1 - Made it to case BoatPosition.Offset first if");
                        initialLocationMode = BoatPosition.Offset; 
                    }

                    else if(valueX <= 2 || valueY <= 5.5 || valueZ <= 2 || valueX >= -2
                        || valueY >= 3.5 || valueZ >= -2)
                    {
                        //Debug.Log("1 - Made it to case BoatPosition.Offset else if");
                        initialLocationMode = BoatPosition.Standard;
                    }

                    break;

                case BoatPosition.Standard:
                    if (valueX <= 2 || valueY <= 5.5 || valueZ <= 2 || valueX >= -2
                        || valueY >= 3.5 || valueZ >= -2)
                    {
                        //Debug.Log("1 - Made it to case BoatPosition.Standard if");
                        initialLocationMode = BoatPosition.Standard;
                    }

                    break;
            }

            DoAction(initialLocationMode);

        }

        protected void DoAction(BoatPosition location)
        {
            //Debug.Log("2 - Made it to DoAction");
            switch (location)
            {
                case BoatPosition.Standard:
                    //Debug.Log("2 - Made it to case BoatPosition.Standard:");
                    // do nothing
                    break;

                case BoatPosition.Offset:
                    // move ship back to original
                    //Debug.Log("2 - Made it to case BoatPosition.offset: ");
                    transform.position = new Vector3(0f, 4.5f, 0f);
                    break;
            }
        }
    }
}
