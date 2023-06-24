using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public Transform Object; // Needs rigidbody attached with a collider
    public Rigidbody rb;
    Vector3 vel; // Holds the random velocity
    public float switchDirection = 0.5f;
    public float curTime = 0f;
    float force = 10;

    void Start()
    {
        SetVel();
        rb = GetComponent<Rigidbody>();
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
        rb.velocity = vel;
    }

    void OnCollisionEnter(Collision col)
    {
        Vector3 reverseDirection = col.contacts[0].normal - transform.position;
        reverseDirection = -reverseDirection.normalized;
        GetComponent<Rigidbody>().AddForce(reverseDirection * force);
    }
}

       


