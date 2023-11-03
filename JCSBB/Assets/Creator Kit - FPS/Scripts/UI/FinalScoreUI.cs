using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreUI : MonoBehaviour
{
    public static FinalScoreUI Instance { get; private set; }
    
    public Text FinalScore;
    public Text HighScore;
    public GameManager Score;
    [SerializeField]
    private FloatSO scoreSO;
    
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
        GameSystem.Instance.StopTimer();
        GameManager.Instance.DisplayCursor(true);
        Time.timeScale = 0;
        CameraMove.Instance.SetPositionFixed(true);
        FinalScore.text = scoreSO.Value + "";
    }
}
