using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineEnemy_F : MonoBehaviour
{
    public Transform[] patrolPoint;
    Animator animator;
    public float moveSpeed;
    public int destinationPoint;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("notWalking", false);
        animator.SetBool("walkingRight", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (destinationPoint == 0)
        {
            transform.localScale = new Vector2(1, 1);
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[0].position) < Mathf.Epsilon)
            {
                destinationPoint = 1;
            }
        }
        if (destinationPoint == 1)
        {
            transform.localScale = new Vector2(-1, 1);
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[1].position) < Mathf.Epsilon)
            {
                destinationPoint = 0;
            }
        }
    }
}
