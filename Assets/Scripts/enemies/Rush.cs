using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rush : MonoBehaviour
{
    // Start is called before the first frame update
    private float dirX;
    private float moveSpeed = 7.0f;
    private Rigidbody2D rb;
    private AudioSource aud;

    public RawImage Rw;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        dirX= -1.0f;
        Rw.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 9.0f)
        {
            dirX = 1.0f;
        }
        else if (transform.position.y > 9f)
        {
            dirX = -1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            aud.Play();
            Rw.gameObject.SetActive(true);
        }
        else if (other.gameObject.name.Equals("Player"))
        {
            aud.Stop();
        }
    }
}
