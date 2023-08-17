using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreUI : MonoBehaviour
{
    public static FinalScoreUI Instance { get; private set; }
    
    public Text TargetDestroyed;
    public Text NonTargetDestroyed;
    public Text FinalScore;
    
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
        GameManager.Instance.DisplayCursor(true);
        int targetDestroyed = GameManager.Instance.DestroyedTarget;
        int totalTarget = GameManager.Instance.TargetCount;

        TargetDestroyed.text = targetDestroyed + "/" + totalTarget;

        FinalScore.text = Score.Instance.score.ToString();

    }
}
