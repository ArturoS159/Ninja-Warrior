using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public int hp;
    public int score;
    public float sprintSpeed = 9f;
    public float moveSpeed = 7f;
    public float jumpHeight = 13f;
    public float highJump = 20f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enamyLayer;
    public GameObject pauseMenu = null;
    public Vector3 playerPosition;
    public String sceneName;
    private float playerSpeed;
    private bool rotateLeft = true;
    private bool rotateRight = false;
    private bool canJump = false;
    private bool canJumpWall = false;
    private bool paused = false;
    private bool canGetDamage = false;
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
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (SceneManager.GetActiveScene().buildIndex != 3 && SaveSystem.GetInt("Load")==0)
            {
                Debug.Log("NEXt");
                hp = SaveSystem.GetInt("Hp");
                score = SaveSystem.GetInt("Score");
                GameplayController.lifeCounter.text = "x" + hp;
                GameplayController.scoreCounter.text = "x" + score;
            }
            else
            {
                Debug.Log("START");
                hp = 4;
                score = 0;
            }
            if (SaveSystem.GetInt("Load") == 1)
            {
                Debug.Log("LOADED");
                this.transform.position = SaveSystem.GetVector3("PlayerPos");
                this.hp = SaveSystem.GetInt("Health");
                this.score = SaveSystem.GetInt("Scorre");
                SaveSystem.SetInt("Load", 0);
                this.incrementLife();
                this.decrementLife();
                this.incrementScore();
                this.decrementScore();
                //UP reset after load
            }
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSpeed = moveSpeed;
        wearCharacter();
        if (SceneManager.GetActiveScene().buildIndex != 1)
            pauseMenu.SetActive(false);
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
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            playerPosition = this.transform.position;
            sceneName = SceneManager.GetActiveScene().name;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            return (true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "tower")
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
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            FindClosestTower().GetComponent<TurretAttack>().resetAt(true);
            if(animator!=null)
                animator.SetBool("move", false); //move animate


            ////////////////////MOVE RIGHT\\\\\\\\\\\\\\\\\\\\\
            if (Input.GetAxis("Horizontal") > 0)
            {
                canGetDamage = true;
                animator.SetBool("move", true); //move animate
                if(canJump)
                    SoundManagerScript.play("move");

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
                canGetDamage = true;
                animator.SetBool("move", true); //move animate
                if (canJump)
                    SoundManagerScript.play("move");

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
                if (animator != null)
                {
                    animator.SetBool("atack1", false);
                    animator.SetBool("atack2", false);
                    animator.SetBool("atack3", false);
                }
            }
            ////////////////////Jump\\\\\\\\\\\\\\\\\\\\\
            if (Input.GetAxis("Vertical") > 0)
            {
                if (canJump)
                {
                    SoundManagerScript.play("jump");
                    canJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                }
            }
        }
    }

    void atack()
    {
        int rand = UnityEngine.Random.Range(1, 4);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Rogue_attack_01") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Rogue_attack_02") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Rogue_attack_03"))
        {
            SoundManagerScript.play("attack" + rand);
            animator.SetBool("atack" + rand, true);
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enamyLayer);
            foreach (Collider2D enemy in hitEnemys)
            {
                if (enemy.name == "orc")
                {
                    SoundManagerScript.play("orcdeath");
                    enemy.GetComponent<ParticleSystem>().Play();
                    Destroy(enemy.gameObject, 0.3f);
                }
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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            decrementLife();
        }
        if (collision.gameObject.CompareTag("Dmg"))
        {
            decrementLife();
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        if (collision.gameObject.CompareTag("Jump_Bonus"))
        {
            SoundManagerScript.play("jumpbooster");
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
        if(collision.tag == "sword"&&canJump&&canGetDamage)
        {
            decrementLife();
            if (rotateLeft)
            {
                rb.velocity = new Vector2(-10, 0);
            }
            else
            {
                rb.velocity = new Vector2(10, 0);
            }
            canGetDamage = false;
        }

    }

    public void incrementLife()
    {
        SoundManagerScript.play("hearth");
        hp ++;
        GameplayController.lifeCounter.text = "x"+hp;
    }
    public void decrementLife()
    {
        SoundManagerScript.play("damage");
        if(animator!=null)
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
        SoundManagerScript.play("coin");
        score++;
        GameplayController.scoreCounter.text = "x" + score;
    }
    public void decrementScore()
    {
        score--;
        GameplayController.scoreCounter.text = "x" + score;
    }
    private void deathCharacter()
    {
        animator.SetBool("death", true);
        SceneManager.LoadScene("GameOver");
    }

    public GameObject FindClosestTower()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("tower");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = this.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}