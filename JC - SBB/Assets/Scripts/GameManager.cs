using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] theEnemies;
    public int xPos;
    public int yPos;
    public int zPos;
    public int enemyCount;

    public Text timer;
    public Text startCountdown;

    public float totalTimer;
    public float totalStartCountdown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyCountCheck());
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

    }
    void SpawnEnemies()
    {
        xPos = Random.Range(5, -5);
        yPos = Random.Range(20, 10);
        zPos = Random.Range(5, -5);
        Instantiate(theEnemies[Random.Range(0, theEnemies.Length)], new Vector3(xPos, yPos, zPos), Quaternion.identity);
        enemyCount += 1;
    }

    IEnumerator EnemyCountCheck()
    {
        yield return new WaitForSeconds(4f);
        if(enemyCount <= 9)
        {
            SpawnEnemies();
        }
        StartCoroutine(EnemyCountCheck());
    }
}
