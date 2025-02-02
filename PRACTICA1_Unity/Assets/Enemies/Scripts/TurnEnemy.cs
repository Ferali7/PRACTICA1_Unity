using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemy : MonoBehaviour
{
    public void rotateEnemy()
    {
        transform.Rotate(0.0f, 0.0f, 180f, Space.World);
    }
    IEnumerator delay2seconds()
    {
        yield return new WaitForSeconds(4.0f);
        rotateEnemy();
        StartCoroutine(delay2seconds());
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay2seconds());
    }
}