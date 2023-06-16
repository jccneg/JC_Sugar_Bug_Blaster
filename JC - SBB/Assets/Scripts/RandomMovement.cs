using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public Transform Object; // Needs rigidbody attached with a collider
    Vector3 vel; // Holds the random velocity
    public float switchDirection = 0.5f;
    public float curTime = 0f;
 
    void Start()
    {
        SetVel();
    }

    void SetVel()
    {
        if (Random.value > .5)
        {
            vel.x = 2 * 2 * Random.value;
        }
        else
        {
            vel.x = -2 * 2 * Random.value;
        }
        if (Random.value > .5)
        {
            vel.z = 2 * 2 * Random.value;
        }
        else
        {
            vel.z = -2 * 2 * Random.value;
        }
        if (Random.value > .5)
        {
            vel.y = 2 * 2 * Random.value;
        }
        else
        {
            vel.y = -2 * 2 * Random.value;
        }
    }

    void Update()
    {
        if (curTime < switchDirection)
        {
            curTime += 1 * Time.deltaTime;
        }
        else
        {
            SetVel();
            if (Random.value > .5)
            {
                switchDirection += Random.value;
            }
            else
            {
                switchDirection -= Random.value;
            }
            if (switchDirection < 1)
            {
                switchDirection = 1 + Random.value;
            }
            curTime = 0;
        }
    }

    void FixedUpdate()
    {
        Object.GetComponent<Rigidbody>().velocity = vel;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            SetVel();
        }
        SetVel();
    }
}

       


