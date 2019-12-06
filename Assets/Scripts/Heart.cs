using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float speed = 220.0f;

    private void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D ot)
    {
        if (ot.gameObject.CompareTag("Player"))
        {
            ot.gameObject.GetComponent<PlayerController>().incrementLife();
        }
    }
}
