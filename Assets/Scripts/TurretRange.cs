using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("tower");
        foreach(GameObject turret in turrets)
        {
            if(collision.tag=="Player")
                turret.GetComponent<TurretAttack>().setIsAttack(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("tower");
        foreach (GameObject turret in turrets)
        {
            if (collision.tag == "Player")
                turret.GetComponent<TurretAttack>().setIsAttack(false);
        }
    }

}
