using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public GameObject target;
    public GameObject startPos;
    public GameObject bulletPrefab;
    public float speedBullet = 7f;
    private Vector2 moveDir;

    internal void attack(Collider2D colision){
        if (colision.tag.CompareTo("Player").Equals(0))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, startPos.transform.position, startPos.transform.rotation);
            //moveDir = (target.transform.position - transform.position).normalized * speedBullet;
            //Debug.Log(moveDir);
            //bullet.GetComponent<Rigidbody2D>().AddForce(target.transform.right * speedBullet * Time.deltaTime);

            Vector2 dir = (target.transform.position).normalized;
            Debug.Log(dir);
            //bullet.GetComponent<Rigidbody2D>().AddForce(dir * 5 * Time.deltaTime, ForceMode2D.Force);
        }
    }
}
