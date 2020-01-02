using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{

    public Animator MyAnimator { get; private set; }
    public bool Attack { get; set; }
    
    [SerializeField]
    protected float movementSpeed  = 4;
    private float hp;
    protected bool facingRight;

    public virtual void Start()
    {
        MyAnimator = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Edge")
        {
            ChangeDirection();
        }
    }
}
