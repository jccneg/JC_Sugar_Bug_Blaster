using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationY += speedH * Input.GetAxis("Mouse X");
        rotationX -= speedV * Input.GetAxis("Mouse Y");

        rotationY = Mathf.Clamp(rotationY, -30f, 30f);
        rotationX = Mathf.Clamp(rotationX, -30f, 30f);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0.0f);

    

    }
}