using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
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
        xPos = Random.Range(10, -10);
        yPos = Random.Range(15, -15);
        zPos = Random.Range(15, -5);
        Instantiate(theEnemies[Random.Range(0, theEnemies.Length)], new Vector3(xPos, yPos, zPos), Quaternion.identity);
        enemyCount += 1;
    }

    IEnumerator EnemyCountCheck()
    {
        if(enemyCount <= 9)
        {
            SpawnEnemies();
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(EnemyCountCheck());
    }
}
