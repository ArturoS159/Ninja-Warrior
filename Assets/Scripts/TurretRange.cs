using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRange : MonoBehaviour
{
    private bool wait;
    private void Start()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (!wait)
        {
            StartCoroutine(Wait(collision));
        }

    }
    IEnumerator Wait(Collider2D collision)
    {
        wait = true;
        yield return new WaitForSeconds(4);
        GameObject.Find("tower").GetComponent<TurretAttack>().attack(collision);
        wait = false;
    }

}
