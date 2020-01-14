using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speedBullet = 3f;
    private GameObject player;
    private bool isAttack= false;
    private bool wait;
    private bool at = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator Attack()
    {
        wait = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(1, 4));
        if (at)
        {
            Instantiate(bulletPrefab, FindClosestStartPos().transform.position, transform.rotation);
            SoundManagerScript.play("towerShoot");
            at = false;
        }
        wait = false;
    }


    internal void resetAt(bool val)
    {
        at = val;
    }
    private void Update()
    {
        if (isAttack)
        {
            if (!wait)
            {
                StartCoroutine(Attack());
            }
            else
            {
                StopCoroutine(Attack());
            }
            
        }
    }
    internal void setIsAttack(bool val)
    {
        isAttack = val;
    }

    public GameObject FindClosestStartPos()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("StartPos");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.transform.position;
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
