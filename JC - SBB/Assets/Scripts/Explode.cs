using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explode : MonoBehaviour
{
    public bool isDestroyed = false;
    public ParticleSystem explode;
    public RandomPlayer HitPlayer;
    public float pointsWorth;


    // Start is called before the first frame update
    void Start()
    {
        //explode = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed == true)
        {
            Instantiate(explode, transform.position, transform.rotation);
            HitPlayer.PlayRandom();
            Destroy(gameObject);
            isDestroyed = false;
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<Score>().AddScore((int)pointsWorth);
        }
    }
}
