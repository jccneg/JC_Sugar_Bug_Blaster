using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    GameObject enemy;
    public GameManager enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Enemy")
                { 
                    enemy = hit.transform.gameObject;
                    enemy.GetComponent<Explode>().isDestroyed = true;
                    enemies.enemyCount -= 1;
                }

            }
        }
    }
}
