using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D ot)
    {

        if (ot.gameObject.CompareTag("Player"))
        {
            GameplayController.instance.DecrementLife();
        }


    }
}

