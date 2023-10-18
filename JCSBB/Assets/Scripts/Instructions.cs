using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public static Instructions Instance { get; private set; }

    public GameObject Title;
    public GameObject Play;
    public GameObject instructions;
    public GameObject Credits;


    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Display()
    {
        gameObject.SetActive(true);
        Title.SetActive(false);
        Play.SetActive(false);
        instructions.SetActive(false);
        Credits.SetActive(false);
    }

    public void Undisplay()
    {
        gameObject.SetActive(false);
        Title.SetActive(true);
        Play.SetActive(true);
        instructions.SetActive(true);
        Credits.SetActive(true);
    }
}
