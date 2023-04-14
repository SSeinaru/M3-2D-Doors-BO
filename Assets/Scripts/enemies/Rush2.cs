using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rush2 : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.Play();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            aud.Stop();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            aud.Play();
        }
    }
}
