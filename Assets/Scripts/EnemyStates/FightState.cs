using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : IEnemyState
{
    private float attackTimer;
    private float attackCooldown = 10;
    private bool canAttack = true;
    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Attack();
        if(enemy.InRange && !enemy.InFightRange)
        {
            enemy.ChangeState(new RangedState());
        }
        else if(enemy.Target == null)
        {
            enemy.ChangeState(new IdleState());
        }
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;

        if(attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
        }
        if(canAttack)
        {
            canAttack = false;
            enemy.MyAnimator.SetTrigger("attack");
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }
}
