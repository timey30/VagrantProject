using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioColision : MonoBehaviour
{
    public AudioSource wallSource;
    // Start is called before the first frame update
    void Start()
    {
        wallSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Wall")
        {
            wallSource.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Wall")
        {
            wallSource.Stop();
        }
    }
}
