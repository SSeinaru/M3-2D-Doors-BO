using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public bool canHide = false;

    public bool Hiding = false;

    public SpriteRenderer sprite;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        sprite= rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canHide && Input.GetKeyDown(KeyCode.E)) 
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            sprite.sortingOrder = 0;
            Hiding= true;
        }

        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            sprite.sortingOrder = 2;
            Hiding= false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Closet"))
        {
            canHide= true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Closet"))
        {
            canHide= false;
        }
    }
}
