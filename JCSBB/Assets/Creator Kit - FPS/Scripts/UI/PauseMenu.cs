using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

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
    }

    public void ReturnToGame()
    {
        UIAudioPlayer.PlayPositive();
        GameSystem.Instance.StartTimer();
        gameObject.SetActive(false);
        GameManager.Instance.DisplayCursor(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
