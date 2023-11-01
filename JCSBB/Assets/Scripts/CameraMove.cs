using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    public static CameraMove Instance { get; private set; }

    public Transform target;
    public float movementTime = 1;
    public float rotationSpeed = 0.1f;

    Vector3 refPos;
    Vector3 refRot;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private bool _isPositionFixed = false;
    private Vector3 _fixedPosition;
    FadeInOut fade;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fade = FindObjectOfType<FadeInOut>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.EndLevel == false)
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

        if (GameManager.Instance.EndLevel == true)
        {
            if (!target)
                return;
            StartCoroutine(_ChangeScene());
            //Interpolate Position
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref refPos, movementTime);
            //Interpolate Rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void SetPositionFixed(bool fix)
    {
        _isPositionFixed = true;
        _fixedPosition = transform.position;
    }

    public IEnumerator _ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(3);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}