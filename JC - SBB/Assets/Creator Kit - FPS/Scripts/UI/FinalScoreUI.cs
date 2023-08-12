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
        int targetDestroyed = GameSystem.Instance.DestroyedTarget;
        int totalTarget = GameSystem.Instance.TargetCount;

        TargetDestroyed.text = targetDestroyed + "/" + totalTarget;

        FinalScore.text = GameSystem.Instance.Score.ToString("N");
    }
}
