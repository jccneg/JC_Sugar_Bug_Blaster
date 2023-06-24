using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] theEnemies;
    public int xPos;
    public int yPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyCountCheck());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yield return new WaitForSeconds(1f);
        if(enemyCount <= 9)
        {
            SpawnEnemies();
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyCountCheck());
    }
}
