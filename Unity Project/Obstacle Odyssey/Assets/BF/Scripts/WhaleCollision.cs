using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleCollision : MonoBehaviour
{
    private float damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("caravel").SendMessage("HealthChangeDamage", damage);
    }
}

