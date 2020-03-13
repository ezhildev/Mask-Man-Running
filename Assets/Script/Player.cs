using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player : MonoBehaviour
{
    private float JumpForce = 11f, maxSlidingTime = 0.7f, slidingTime = 0f;
    private bool slide = false, isGround = false;
    public bool isJumpBtn = false, isSlideBtn = false;

    private Rigidbody2D PlayerPhysics;
    private Animator playerAnimation;
    void Start()
    {
        PlayerPhysics = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    
    void Update()
    {
        playerAnime();
        playerController();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGround = false;
        }
    }

    private void playerJump()
    {
        if ((!slide && isGround) && ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) || isJumpBtn))
        {
            PlayerPhysics.velocity = new Vector2(transform.position.x, JumpForce);
        }
    }

    private void playerSlide()
    {
        if((Input.GetKeyDown(KeyCode.DownArrow) || isSlideBtn) && isGround)
        {
            slide = true;
            slidingTime = 0f;
        }

        if(slide)
        {
            slidingTime += Time.deltaTime;
            if (slidingTime >= maxSlidingTime)
            {
                slide = false;
                isSlideBtn = false;
            }
        }
    }

    private void playerAnime()
    {
        playerAnimation.SetBool("IsJump", isGround);
        playerAnimation.SetBool("IsSlide", slide);
    }

    void playerController()
    {
        playerJump();
        playerSlide();
    }

    public void playerDestroy()
    {
        playerAnimation.SetTrigger("IsDead");
        Destroy(this.gameObject, .5f);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
