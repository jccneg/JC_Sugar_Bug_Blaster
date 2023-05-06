using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public bool isDestroyed = false;
    public ParticleSystem explode;
    private Transform cubePos;

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
            StartCoroutine(TimeToExplode());
        }
    }

    IEnumerator TimeToExplode()
    {
        explode.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
