using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public int hp = 4;
    public int score = 0;
    public float sprintSpeed = 9f;
    public float moveSpeed = 7f;
    public float jumpHeight = 13f;
    public float highJump = 20f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enamyLayer;
    private float playerSpeed;
    private bool rotateLeft = true;
    private bool rotateRight = false;
    private bool canJump = false;
    private bool canJumpWall = false;
    private bool paused = false;
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxColider2D;
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
        boxColider2D = GetComponent<BoxCollider2D>();
        playerSpeed = moveSpeed;
        wearCharacter();
    }
    void Update()
    {
        moveCharacter();
        if (Input.GetButtonDown("Cancel"))
            paused = togglePause();
    }

    private bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
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
        animator.SetBool("atack" + UnityEngine.Random.Range(1, 4), true);
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enamyLayer);
        foreach(Collider2D enemy in hitEnemys)
        {
            if (enemy.tag=="Orc")
            {
                Debug.Log(enemy.name);
                Destroy(enemy.gameObject);
            }
        }
    }

    void wearCharacter()
    {
        if (SceneManager.GetActiveScene().name != "CharacterLevel")
        {
            this.GetComponent<CharacterWear>().loadWear();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("heart"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Jump_Bonus"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(TimeJump());

            IEnumerator TimeJump()
            {
                float jumpHeight2 = jumpHeight;
                jumpHeight = highJump;
                yield return new WaitForSeconds(5);
                jumpHeight = jumpHeight2;
            }



        }
        if(collision.tag == "sword")
        {
            decrementLife();
        }

    }

    public void incrementLife()
    {
        hp ++;
        GameplayController.lifeCounter.text = "x"+hp;
    }
    public void decrementLife()
    {
        animator.SetTrigger("hit");
        if (hp - 1 <= 0)
        {
            deathCharacter();
        }
        hp--;
        GameplayController.lifeCounter.text = "x" + hp;
        
    }
    public void decrementLife(int hp)
    {
        if (this.hp < hp)
        {
            deathCharacter();
        }
        else
        {
            this.hp -= hp;
        }
        GameplayController.lifeCounter.text = "x" + hp;
    }
    public void incrementScore()
    {
        score++;
        GameplayController.scoreCounter.text = "x" + score;
    }

    private void deathCharacter()
    {
        animator.SetBool("death", true);

    }
}