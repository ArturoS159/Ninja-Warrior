using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour
{
    public Transform pos1, pos2;
    public float moveSpeed = 500;
    public Transform startPos;

    Vector3 nextPos;
    void Start()
    {
        nextPos = startPos.position;
    }
    void Update()
    {
        if (transform.position.x == pos1.position.x)
        {
            nextPos = pos2.position;
        }

        if (transform.position.x == pos2.position.x)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(nextPos.x, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }


}
