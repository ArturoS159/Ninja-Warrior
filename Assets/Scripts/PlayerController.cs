using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public int hp=5;
    // public float sprintSpeed = 4f;
    public float walkSpeed = 7f;
    public float jumpHeight = 8f;

    // private bool isMoving = false;
    // private bool isSprinting =false;
    private bool rotateLeft = true;
    private bool rotateRight = false;
    private bool canJump = false;
    private bool canJumpWall = false;
    private Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveCharacter();
    }


    void moveCharacter()
    {
        //Move right
        if (Input.GetAxis("Horizontal") > 0)
        {
            if(rotateRight){
                transform.Rotate(0,180,0);
                rotateRight = false;
                rotateLeft = true;
            }
            rb.velocity = new Vector2 (Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);
        }//Move left
        else if(Input.GetAxis("Horizontal") < 0){
            if(rotateLeft){
                transform.Rotate(0,180,0);
                rotateLeft = false;
                rotateRight = true;
            }
            rb.velocity = new Vector2 (Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);
        }
        //Jump
        if(Input.GetAxis("Vertical") > 0){
            if(canJump){
                canJump = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            } 
        }
    } 
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            canJumpWall = false;
        }
        if(collision.gameObject.tag == "Wall" && !canJumpWall && Input.GetAxis("Vertical") > 0){
            canJumpWall = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

}