using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D ot)
    {

        if (ot.gameObject.CompareTag("Player"))
        {
            ot.gameObject.GetComponent<PlayerController>().incrementScore();
        }


    }
}
