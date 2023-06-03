using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public bool isDestroyed = false;
    public ParticleSystem explode;

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
            Destroy(gameObject);
            isDestroyed = false;
        }
    }
}
