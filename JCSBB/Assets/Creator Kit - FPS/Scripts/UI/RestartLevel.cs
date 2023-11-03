using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void Restart()
    {
        UIAudioPlayer.PlayPositive();
        GameSystem.Instance.StartTimer();
        GameManager.Instance.DisplayCursor(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
