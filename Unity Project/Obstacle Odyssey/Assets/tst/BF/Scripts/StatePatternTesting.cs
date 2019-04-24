/* Brandon Foss
 * This script will test the state pattern starting the boat in a far off position
 * and testing to see whether the script implementing the state pattern correctly
 * moves the ship to the starting position
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // allows text manipulation
using UnityEngine.SceneManagement;

public class StatePatternTesting : MonoBehaviour
{
    public Text PatternText1; // creates the Text object which is attached to HUD canvas
    public Text PatternText2; // creates the Text object which is attached to HUD canvas
    public Text PatternText3; // creates the Text object which is attached to HUD canvas

    float valueX;
    float valueY;
    float valueZ;
    bool check = false;
    bool flag = false;
    private IEnumerator coroutine;

    // will initialize hud text with values of ship coordinates
    void Awake()
    {
        valueX = this.gameObject.transform.position.x;
        valueY = this.gameObject.transform.position.y;
        valueZ = this.gameObject.transform.position.z;
        PatternText1.text = "Initial Location: x =  " + valueX + ", y =  " + valueY + ", z =  " + valueZ;
    }

    // Start is called before the first frame update
    void Start()
    {
        valueX = this.gameObject.transform.position.x;
        valueY = this.gameObject.transform.position.y;
        valueZ = this.gameObject.transform.position.z;
        check = false;
        PatternText2.text = "New Location: y =  " + valueX + ", y =  " + valueY + ", z =  " + valueZ;
        coroutine = WaitAndChangeScene(17.0f);
    }

    // Update will constantly update new position after it is moved
    void Update()
    {
        if(check == true)
        {
            if (flag == false)
            {
                StartCoroutine(coroutine);
                //enabled = false;
            }

            flag = true;
        }

        valueX = this.gameObject.transform.position.x;
        valueY = this.gameObject.transform.position.y;
        valueZ = this.gameObject.transform.position.z;
        PatternText2.text = "New Location: X =  " + valueX + ", y =  " + valueY + ", z =  " + valueZ;

        // checks location of ship and displays message if inside standard ship boundaries
        if (valueX <= 2.5 && valueY <= 5.5 && valueZ <= 2.5 && valueX >= -2.5
                        && valueY >= 0 && valueZ >= -2.5)
        {
            if (check == false)
            {
                check = true;
            }
            PatternText3.color = Color.green;
            PatternText3.text = "Successfully moved ship to standard starting location";
        }

        // checks location of ship and displays message if outside standard ship boundaries
        else if (valueX >= 2 || valueY >= 5.5 || valueZ >= 2 || valueX <= -2
                        || valueY <= 3.5 || valueZ <= -2)
        {
            PatternText3.color = Color.red;
            PatternText3.text = "Failed to move ship to standard starting location";
        }
    }

    // will move the test scene to the lobby scene
    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Returned from wait time");
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
