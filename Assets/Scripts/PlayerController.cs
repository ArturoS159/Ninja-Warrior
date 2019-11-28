using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public int hp = 5;
    public float sprintSpeed = 9f;
    public float moveSpeed = 7f;
    public float jumpHeight = 8f;
    private float playerSpeed;
    private bool rotateLeft = true;
    private bool rotateRight = false;
    private bool canJump = false;
    private bool canJumpWall = false;
    private Rigidbody2D rb;
    private Animator animator;
    public int hood;
    public int face;
    public int shoulder;
    public int elbow;
    public int wrist;
    public int weapon;
    public int torso;
    public int pelvis;
    public int leg;
    public int boot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSpeed = moveSpeed;
        wearCharacter();
    }
    void Update()
    {
        moveCharacter();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            canJumpWall = false;
        }
        if (collision.gameObject.tag == "Wall" && !canJumpWall && Input.GetAxis("Vertical") > 0)
        {
            canJumpWall = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }
    void moveCharacter()
    {
        animator.SetBool("move", false); //move animate
        ////////////////////MOVE RIGHT\\\\\\\\\\\\\\\\\\\\\
        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("move", true); //move animate
            if (rotateRight)
            {
                transform.Rotate(0, 180, 0);
                rotateRight = false;
                rotateLeft = true;
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y);
        } ////////////////////MOVE LEFT\\\\\\\\\\\\\\\\\\\\\
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("move", true); //move animate
            if (rotateLeft)
            {
                transform.Rotate(0, 180, 0);
                rotateLeft = false;
                rotateRight = true;
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y);
        }
        ////////////////////SPRINT\\\\\\\\\\\\\\\\\\\\\
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = moveSpeed;
        }
        ////////////////////ATACK\\\\\\\\\\\\\\\\\\\\\
        if (Input.GetKeyDown(KeyCode.Space) && !canJumpWall)
        {
            atack();
        }
        else
        {
            animator.SetBool("atack1", false);
            animator.SetBool("atack2", false);
            animator.SetBool("atack3", false);
        }
        ////////////////////Jump\\\\\\\\\\\\\\\\\\\\\
        if (Input.GetAxis("Vertical") > 0)
        {
            if (canJump)
            {
                canJump = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }
    }

    void atack()
    {
        animator.SetBool("atack" + Random.Range(1, 4), true);
    }

    void wearCharacter()
    {
        if (SceneManager.GetActiveScene().name != "CharacterLevel")
        {
            this.GetComponent<CharacterWear>().loadWear();
        }
    }
}