using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFlock : MonoBehaviour
{
    // Start is called before the first frame update
    private int amount;
    private float radius;
    private float range;
    private float speed;
    GameObject[] Birds;
    void Start()
    {
        amount = 10;
        radius = 30;
        range = 15f;
        speed = 10f;
        WockaFlockaFlock(amount, range, radius, speed);
        return;
    }

    private void WockaFlockaFlock(int amount, float range, float radius, float speed)
    {
        InstantiateBirds(amount, range);
        StartCoroutine(Fly(Birds, amount, radius, speed));
        return;
    }

    private void InstantiateBirds(int amount, float range)
    {
        Birds = new GameObject[amount];
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 
                Random.Range(transform.position.x - range, transform.position.x + range) / 4,
                Random.Range(transform.position.x - range, transform.position.x + range));

            Birds[i] = Instantiate(GameObject.Find("Bird"), position, transform.rotation, this.transform) as GameObject;
        }
        return;
    }

    IEnumerator Fly(GameObject[] Birds, int amount, float radius, float speed)
    {
        float time = 0;
        for (; ;)
        {
            time += Time.deltaTime;

            var x = transform.position.x;
            transform.position = Quaternion.AngleAxis(-time*speed, Vector3.up) * new Vector3(radius, 0f);
            var new_x = transform.position.x;
            var x_change = new_x - x;

            var change = ((x_change * speed) / radius);
            //(speed * radius) / (( radius/speed )* 360)
            for (int i = 0; i < amount; i++)
            {
                Birds[i].transform.Rotate(0, (change) , 0);
            }
            yield return null;
        }
    }
}
