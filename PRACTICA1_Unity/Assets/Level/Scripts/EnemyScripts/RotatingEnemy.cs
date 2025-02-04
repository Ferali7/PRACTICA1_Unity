using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    public bool Stop = false;
    public void rotateEnemy()
    {
        transform.Rotate(0.0f, 0.0f, 90f, Space.World);
    }
    IEnumerator delay2seconds()
    {
        if (Stop)
        {
        }
        else
        {
            yield return new WaitForSeconds(2.0f);
            rotateEnemy();
            StartCoroutine(delay2seconds());
        }   
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay2seconds());
    }
}
