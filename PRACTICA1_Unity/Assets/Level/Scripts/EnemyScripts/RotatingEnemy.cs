using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    //Script creat per crear enemics que van donant voltes
    public bool Stop = false;
    public void rotateEnemy() //fem que giri la llum i la trigger box 90 graus cada cop que es crida la funció
    {
        transform.Rotate(0.0f, 0.0f, 90f, Space.World);
    }
    IEnumerator delay2seconds()//fa que giri cada dos segons
    {
        if (Stop) //per el cas que volguem que es pari el joc quan et pillen, depen dle temps ho utilitzarem o no (?)
        {
        }
        else
        {
            yield return new WaitForSeconds(2.0f); //li indiquem el temps que volem que faci la volta
            rotateEnemy(); //rota
            StartCoroutine(delay2seconds()); //repeteix el loop
        }   
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay2seconds());
    }
}
