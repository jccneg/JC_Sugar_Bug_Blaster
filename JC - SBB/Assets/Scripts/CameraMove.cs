using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static CameraMove Instance { get; private set; }

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private bool _isPositionFixed = false;
    private Vector3 _fixedPosition;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotationY += speedH * Input.GetAxis("Mouse X");
        rotationX -= speedV * Input.GetAxis("Mouse Y");

        rotationY = Mathf.Clamp(rotationY, -60f, 60f);
        rotationX = Mathf.Clamp(rotationX, -65f, 65f);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0.0f);

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (_isPositionFixed)
        {
            transform.position = _fixedPosition;
        }
    }

    public void SetPositionFixed(bool fix)
    {
        _isPositionFixed = true;
        _fixedPosition = transform.position;
    } 
}