using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif


public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance { get; private set; }

    static int s_CurrentEpisode = -1;
    static int s_CurrentLevel = -1;
    
    public GameObject[] StartPrefabs;
    public float TargetMissedPenalty = 1.0f;
    public AudioSource BGMPlayer;
    public AudioClip EndGameSound;
    
    public float RunTime => m_Timer;
    public int TargetCount => m_TargetCount;
    public int DestroyedTarget => m_TargetDestroyed;
    public int DestroyedNonTarget => m_NonTargetDestroyed;
    public int Score => m_Score;

    float m_Timer;
    bool m_TimerRunning = false;
    
    int m_TargetCount;
    int m_TargetDestroyed;
    int m_NonTargetDestroyed;

    int m_Score = 0;

    void Awake()
    {
        Instance = this;
        foreach (var prefab in StartPrefabs)
        {
            Instantiate(prefab);
        }
        
        PoolSystem.Create();
    }

    void Start()
    {
        WorldAudioPool.Init();
        
        RetrieveTargetsCount();
        
#if UNITY_EDITOR
        //in the editor we find which level we are currently in. Inefficient but since any level can be opened in the
        //editor we can't assume where we start

        string currentScene = SceneManager.GetActiveScene().path;
        for (int i = 0; i < GameDatabase.Instance.episodes.Length && s_CurrentEpisode < 0; ++i)
        {
            for (int j = 0; j < GameDatabase.Instance.episodes[i].scenes.Length; ++j)
            {
                if (GameDatabase.Instance.episodes[i].scenes[j] == currentScene)
                {
                    s_CurrentEpisode = i;
                    s_CurrentLevel = j;
                    break;
                }
            }
        }
        
#else
        //in the final game, we init everything to episode & level 0, as we can't start from somewhere else
        if(s_CurrentEpisode < 0 || s_CurrentLevel < 0)
        {
            s_CurrentEpisode = 0;
            s_CurrentLevel = 0;
        }
#endif
        
        GameSystemInfo.Instance.UpdateTimer(0);
    }

    public void ResetTimer()
    {
        m_Timer = 0.0f;
    }
    
    public void StartTimer()
    {
        m_TimerRunning = true;
    }

    public void StopTimer()
    {
        m_TimerRunning = false;
    }

    public void FinishRun()
    {
        BGMPlayer.clip = EndGameSound;
        BGMPlayer.loop = false;
        BGMPlayer.Play();
        
        Controller.Instance.DisplayCursor(true);
        Controller.Instance.CanPause = false;
        FinalScoreUI.Instance.Display();
    }

    
    void RetrieveTargetsCount()
    {
        var targets = Resources.FindObjectsOfTypeAll<Target>();

        int count = 0;
        
        //The spawner create their target and disable them before that function run, so retrieving all Target will also
        //retrieve the one the spawner will use.
        foreach (var t in targets)
        {
#if UNITY_EDITOR

            //in editor we have to check if the target returned is not a prefab, since Resouces.FindObjectofTypeAll return
            //also loaded prefab. In the player no need as there is no prefab loaded.

            //if the scene isn't valid it's a prefab. 
            if (!t.gameObject.scene.IsValid())
            {
                continue;
            }
#endif
            
            //we only count target with positive point, as negative point you have to avoid destroying them
            if (t.pointValue > 0)
                count += 1;
        }


        m_TargetCount = count;
        m_TargetDestroyed = 0;
        m_Score = 0;

        GameSystemInfo.Instance.UpdateScore(0);
    }

    void Update()
    {
        if (m_TimerRunning)
        {
            m_Timer += Time.deltaTime;
            
            GameSystemInfo.Instance.UpdateTimer(m_Timer);
        }        
    }

    
    public void TargetDestroyed(int score)
    {
        m_TargetDestroyed += 1;
        m_Score += score;

        GameSystemInfo.Instance.UpdateScore(m_Score);
    }

    public void NonTargetDestroyed(int score)
    {
        m_NonTargetDestroyed += 1;
        m_Score -= score;

        GameSystemInfo.Instance.UpdateScore(m_Score);
    }
}
