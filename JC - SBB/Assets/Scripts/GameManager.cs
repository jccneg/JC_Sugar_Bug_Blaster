using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Mechanics")]
    public GameObject[] theEnemies;
    public int xPos;
    public int yPos;
    public int zPos;
    public int enemyCount;
    public GameObject Pause;

    public bool CanPause { get; set; } = true;

    bool m_IsPaused = false;

    float m_Timer;
    bool m_TimerRunning = false;

    [Header("Timers")]
    public Text timer;
    public Text startCountdown;
    public float totalTimer;
    public float totalStartCountdown;


    public static GameManager Instance { get; protected set; }

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(After(EnemyCountCheck(), 3f));
        m_IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (totalStartCountdown > 0)
        {
            totalStartCountdown -= Time.deltaTime;
            startCountdown.text = Mathf.Round(totalStartCountdown).ToString();
        }

        if (totalStartCountdown <= 0)
        {
            startCountdown.text = "";
            totalTimer -= Time.deltaTime;
            timer.text = Mathf.Round(totalTimer).ToString();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Pause.GetComponent<PauseMenu>().Display();
        }

        if (CanPause && Input.GetButtonDown("Menu"))
        {
            PauseMenu.Instance.Display();
        }

        if (m_TimerRunning)
        {
            m_Timer += Time.deltaTime;

            GameSystemInfo.Instance.UpdateTimer(m_Timer);
        }
    }
    void SpawnEnemies()
    {
        xPos = Random.Range(5, -5);
        yPos = Random.Range(20, 10);
        zPos = Random.Range(5, 0);
        Instantiate(theEnemies[Random.Range(0, theEnemies.Length)], new Vector3(xPos, yPos, zPos), Quaternion.identity);
        enemyCount += 1;
    }

    IEnumerator After(IEnumerator coroutine, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        yield return coroutine;
    }

    IEnumerator EnemyCountCheck()
    {
        yield return new WaitForSeconds(.5f);
        if(enemyCount <= 18)
        {
            SpawnEnemies();
        }
        StartCoroutine(EnemyCountCheck());
    }

    public void DisplayCursor(bool display)
    {
        m_IsPaused = display;
        Cursor.lockState = display ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = display;
    }
}
