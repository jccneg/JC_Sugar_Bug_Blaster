using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    [Header("Default Score")]
    public int score = 0;
    [Header("Text Object for Displaying Score")]
    public Text scoreText;

    public void Start()
    {
        scoreText.text = score.ToString();
    }


    public void AddScore(int points)
    {
        score = score + points;
        scoreText.text = score.ToString();
    }
}
