using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        moveDir = (target.transform.position - transform.position).normalized * 5f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveDir.x,moveDir.y);
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Character")
        {
            Destroy(gameObject);
        }
    }

}
