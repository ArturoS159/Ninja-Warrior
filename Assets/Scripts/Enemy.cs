using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyController
{
    private IEnemyState currentState;
    public GameObject Target { get; set; }

    [SerializeField]
    private float fightRange = 3;
    [SerializeField]
    private float inRange = 3;

    [SerializeField]
    private EdgeCollider2D SwordCollider = null;
    

    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute();
        LookAtTarget();
    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }

    public void Move()
    {
        if(!Attack)
        {
            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
        }
    }
    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter(collision);
        
    }

    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    public bool InFightRange
    {
        get
        {
            if(Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= fightRange;
            }
            return false;
        } 
        
    }
    public bool InRange
    {
        get
        {
            if (Target != null)
            {
                
                return Vector2.Distance(transform.position, Target.transform.position) <= inRange;
            }
            return false;
        }
    }

    public void MeleeAttack()
    {
        SwordCollider.enabled = !SwordCollider.enabled;
    }

   
}

