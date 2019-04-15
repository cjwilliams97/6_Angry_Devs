/* Brandon Foss
 * This script will use a state pattern to change the caravel object
 * based on its current state. It is used to return the ship to our standard 
 * starting position if the physics send it elsewhere when loading the level.
 */

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

        // runs update 20 times and continues to update boat based on state
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

        // lists different states the boat can be in
        protected enum BoatPosition
        {
            Standard,
            Offset
        }

        BoatPosition initialLocationMode = BoatPosition.Offset; // sets boat to offset state initially

        // changes the boats state based on position of it
        public virtual void UpdateBoat()
        {
            //Debug.Log("1 - Made it to UpdateBoat");
            float valueX = this.gameObject.transform.position.x;
            float valueY = this.gameObject.transform.position.y;
            float valueZ = this.gameObject.transform.position.z;

            switch (initialLocationMode)
            {
                // indicates boat is still offset and keeps state that way
                case BoatPosition.Offset:
                    if (valueX >= 2 || valueY >= 5.5 || valueZ >= 2 || valueX <= -2
                        || valueY <= 3.5 || valueZ <= -2)
                    {
                        //Debug.Log("1 - Made it to case BoatPosition.Offset first if");
                        initialLocationMode = BoatPosition.Offset; 
                    }

                    // indicates boat is now standard position and switches state from offset to standard 
                    else if (valueX <= 2 && valueY <= 5.5 && valueZ <= 2 && valueX >= -2
                        && valueY >= 3.5 && valueZ >= -2)
                    {
                        //Debug.Log("1 - Made it to case BoatPosition.Offset else if");
                        initialLocationMode = BoatPosition.Standard;
                    }

                    break;
    
                // indicates boat is still in standard position and maintains state
                case BoatPosition.Standard:
                    if (valueX <= 2 && valueY <= 5.5 && valueZ <= 2 && valueX >= -2
                        && valueY >= 3.5 && valueZ >= -2)
                    {
                        //Debug.Log("1 - Made it to case BoatPosition.Standard if");
                        initialLocationMode = BoatPosition.Standard;
                    }

                    // indiactes boat is offset and switches state from standard to offset
                    else if (valueX >= 2 || valueY >= 5.5 || valueZ >= 2 || valueX <= -2
                        || valueY <= 3.5 || valueZ <= -2)
                    {
                        //Debug.Log("1 - Made it to case BoatPosition.Offset first if");
                        initialLocationMode = BoatPosition.Offset;
                    }

                    break;
            }

            // performs action based off of internal state
            DoAction(initialLocationMode);

        }

        // will perform action based on state 
        protected void DoAction(BoatPosition location)
        {
            //Debug.Log("2 - Made it to DoAction");
            switch (location)
            {
                // if standard do nothing
                case BoatPosition.Standard:
                    //Debug.Log("2 - Made it to case BoatPosition.Standard:");
                    // do nothing
                    break;

                // if offset, move boat properly to standard
                case BoatPosition.Offset:
                    // move ship back to original
                    //Debug.Log("2 - Made it to case BoatPosition.offset: ");
                    transform.position = new Vector3(0f, 4.5f, 0f);
                    break;
            }
        }
    }
}
