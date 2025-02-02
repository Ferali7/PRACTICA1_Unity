using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineEnemy : MonoBehaviour
{
    public Transform[] patrolPoint;
    public float moveSpeed;
    public int destinationPoint;
    private Vector2 movement;
    public void rotateEnemy()
    {
        transform.Rotate(0.0f, 0.0f, 180f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if (destinationPoint == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[0].position) < Mathf.Epsilon)
            {
                destinationPoint = 1;
                rotateEnemy();
            }
        }
        if (destinationPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[1].position) < Mathf.Epsilon)
            {
                destinationPoint = 0;
                rotateEnemy();
            }
        }
    }
}
