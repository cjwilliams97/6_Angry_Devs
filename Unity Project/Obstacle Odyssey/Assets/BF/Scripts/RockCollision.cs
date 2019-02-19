using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    private float damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("caravel").SendMessage("HealthChangeDamage", damage);
    }
}

