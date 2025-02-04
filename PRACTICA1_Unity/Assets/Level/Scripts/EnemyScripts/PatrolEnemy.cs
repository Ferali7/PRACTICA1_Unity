using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    //Aquest codi esta creat per rotar l'element de la llum i les trigger box dels enemics, ja que van separades del sprite
    public Transform[] patrolPoint; //Array creada per ficar la ruta que ha de seguir
    public float moveSpeed;
    public int destinationPoint;
    private Vector2 movement;
    public void rotateEnemy()
    {
        transform.Rotate(0.0f, 0.0f, 90f, Space.World);
    }
    void Update() 
    {
        if (destinationPoint == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime); //Aqui li estic dient que es mogui cap a la posicio "point 0"
            if (Vector2.Distance(transform.position, patrolPoint[0].position) < Mathf.Epsilon)  //Aqui li dic que si esta molt molt molt aprop del "point 0" canvii d'objectiu, ara el seu objectiu sera el "point 1"
            { 
                destinationPoint = 1;
                rotateEnemy(); //fem que roti, per tal que la llum i la trigger box mirin cap al lloc adient. Es cert que no és lo més eficient, ja que obliguem a que segueixi una ruta rectangular
            }
        }
        if (destinationPoint == 1) //fa el mateix que amb l'anterior, cada cop canvia segons quina ruta vols que segueixi l'enemic
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[1].position) < Mathf.Epsilon) 
            { 
                destinationPoint = 2;
                rotateEnemy();
            }
        }
        if (destinationPoint == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[2].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[2].position) < Mathf.Epsilon) 
            { 
                destinationPoint = 3;
                rotateEnemy();
            }
        }
        if (destinationPoint == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[3].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[3].position) < Mathf.Epsilon) 
            { 
                destinationPoint = 0; //Per tal de completar el loop, fem que torni al principi! 
                rotateEnemy();
            }
        }
    }
}
