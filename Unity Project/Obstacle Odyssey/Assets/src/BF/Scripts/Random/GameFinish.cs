/* Brandon Foss
 * This script will perform finishing game commands
 * that contact the game finish method from a
 * script on the caravel.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("GameFinish");
    }
}
