using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //De 
    [SerializeField] bool IsGrounded = false;

    public bool isMoving;

    public Animator anim;

    public SpriteRenderer sprite;

    public float moveSpeed = 6f;

    public Rigidbody2D rb;


    private void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;


        //Walking right w/ sprite 
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            sprite.flipX = false;
            anim.SetBool("IsMove", true);
        }
        //Walking right w/ flipped sprite
        else if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            sprite.flipX = true;
            anim.SetBool("IsMove", true);
        }

        //Jump natuurlijk
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boingTimes();
        }
        //Kijkt of ik beweeg en zo niet speelt hij de idle af
        if (!Input.anyKey)
        {
            isMoving = false;
            anim.SetBool("IsMove", false);
            anim.SetBool("IsJump", false);
        }






    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
        Debug.Log(collision.gameObject.name);
        //Stop moving when get hit by rush
        if (collision.gameObject.tag.Equals("Rush"))
        {
            moveSpeed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGrounded = false;
        
    }

    
    //Jump mechanic itself
    private void boingTimes()
    {
        anim.SetBool("IsJump", true);
        rb.AddForce(new Vector3(0, 150, 0));
        anim.SetBool("IsFalling", false);
    }
   
    

}

