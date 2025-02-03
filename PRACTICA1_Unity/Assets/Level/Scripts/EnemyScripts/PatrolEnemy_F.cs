using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy_F : MonoBehaviour
{
    public Transform[] _patrolPoint;
    Animator animator;
    public float _moveSpeed;
    public int _destinationPoint;
    private Vector2 movement;

    private void ResetAnimations()
    {
        animator.SetBool("notWalking", false);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingTop", false);
        animator.SetBool("walkingBottom", false);
    }
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        ResetAnimations();
        animator.SetBool("walkingRight", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (_destinationPoint == 0)
        {
            ResetAnimations();
            animator.SetBool("walkingRight", true);
            transform.position = Vector2.MoveTowards(transform.position, _patrolPoint[0].position, _moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _patrolPoint[0].position) < Mathf.Epsilon) 
            { 
                _destinationPoint = 1;
            }
        }
        if (_destinationPoint == 1)
        {
            ResetAnimations();
            animator.SetBool("walkingBottom", true);
            transform.position = Vector2.MoveTowards(transform.position, _patrolPoint[1].position, _moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _patrolPoint[1].position) < Mathf.Epsilon) 
            { 
                _destinationPoint = 2;
            }
        }
        if (_destinationPoint == 2)
        {
            transform.localScale = new Vector2(-1, 1);
            ResetAnimations();
            animator.SetBool("walkingRight", true);
            transform.position = Vector2.MoveTowards(transform.position, _patrolPoint[2].position, _moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _patrolPoint[2].position) < Mathf.Epsilon) 
            { 
                _destinationPoint = 3;
                transform.localScale = new Vector2(1, 1);
            }
        }
        if (_destinationPoint == 3)
        {
            ResetAnimations();
            animator.SetBool("walkingTop", true);
            transform.position = Vector2.MoveTowards(transform.position, _patrolPoint[3].position, _moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _patrolPoint[3].position) < Mathf.Epsilon) 
            { 
                _destinationPoint = 0;
            }
        }
    }
}