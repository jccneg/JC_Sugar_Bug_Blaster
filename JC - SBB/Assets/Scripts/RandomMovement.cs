using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    float speed;

    public string[] collisionTags = new string[] { "Wall" };
                                                                           
    float step = Mathf.PI / 60;
    float timeVar = 0;
    float rotationRange = 120;                  
    float baseDirection = 0;

    Vector3 randomDirection;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == collisionTags[0])
        {
            baseDirection = baseDirection + Random.Range(-30, 30);
        }
    }

    void Update()
    {
        randomDirection = new Vector3(0, Mathf.Sin(timeVar) * (rotationRange / 2) + baseDirection, 0); 
        timeVar += step;
        speed = Random.Range(minSpeed, maxSpeed);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        transform.Rotate(randomDirection * Time.deltaTime * 5.0f);
    }
}


