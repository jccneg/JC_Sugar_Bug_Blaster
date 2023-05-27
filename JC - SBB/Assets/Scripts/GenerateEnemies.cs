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
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyDrop()
    {
        while (true)
        {
            xPos = Random.Range(5, -5);
            yPos = Random.Range(5, -5);
            zPos = Random.Range(5, -5);
            Instantiate(theEnemies[Random.Range(0, theEnemies.Length)], new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
            enemyCount += 1;
        }
    }
}
