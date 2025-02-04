using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineEnemy : MonoBehaviour
{
    //El funcionament es exactament el mateix que el del Patrol Enemy, alla esta millor explicat
    //Aquest script controla el moviment i el gir de les llums i trigger box
    public Transform[] patrolPoint;
    public float moveSpeed;
    public int destinationPoint;
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
