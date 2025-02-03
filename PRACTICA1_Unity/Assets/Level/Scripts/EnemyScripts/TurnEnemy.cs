using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemy : MonoBehaviour
{
    public void rotateEnemy()
    {
        transform.localScale = new Vector2(-1, 1);
    }
    IEnumerator delaySeconds()
    {
        yield return new WaitForSeconds(4.0f);
        rotateEnemy();
        StartCoroutine(delaySeconds());
    }
    void Start()
    {
        StartCoroutine(delaySeconds());
    }
}