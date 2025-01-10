using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] patrolPoint;
    public float moveSpeed;
    public int destinationPoint;
    public void rotateEnemy()
    {
        transform.Rotate(0.0f, 0.0f, 90f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if (destinationPoint == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[0].position) < .2f) 
            { 
                destinationPoint = 1;
                rotateEnemy();
            }
        }
        if (destinationPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[1].position) < .2f) 
            { 
                destinationPoint = 2;
                rotateEnemy();
            }
        }
        if (destinationPoint == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[2].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[2].position) < .2f) 
            { 
                destinationPoint = 3;
                rotateEnemy();
            }
        }
        if (destinationPoint == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[3].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[3].position) < .2f) 
            { 
                destinationPoint = 0;
                rotateEnemy();
            }
        }
    }
}
