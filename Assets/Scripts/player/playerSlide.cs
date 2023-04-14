using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlide : MonoBehaviour
{
    public bool isSliding = false;
    // Start is called before the first frame update
    public playerMove pl;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer Sprite;
    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;


    public float slideSpeed = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            preformSlide();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Rush"))
        {
            slideSpeed = 0f;
        }
    }

    private void preformSlide() //Slide function
    {
        //Bools true zetten
        isSliding = true;
        anim.SetBool("IsSlide", true);
        
        //colliders veranderens
        regularColl.enabled = false;
        slideColl.enabled= true;

        if (!pl.sprite.flipX)
        {
            rb.AddForce(Vector2.right * slideSpeed);
        }
        else
        {
            rb.AddForce(Vector2.left * slideSpeed);
        }

        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f);
        anim.Play("Idle");
        anim.SetBool("IsSlide", false);
        regularColl.enabled = true;
        slideColl.enabled = false;
        isSliding= false;
    }

}
