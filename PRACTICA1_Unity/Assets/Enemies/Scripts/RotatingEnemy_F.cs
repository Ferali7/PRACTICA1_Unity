using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy_F : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private int directionIndex = 0;
    IEnumerator delay2seconds()
    {
        yield return new WaitForSeconds(2.0f);
        directionIndex++;
        if (directionIndex == 4)
        {
            directionIndex = 0;
        }
        if (directionIndex == 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
        GetComponent<SpriteRenderer>().sprite = sprites[directionIndex];
        StartCoroutine(delay2seconds());
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(-1, 1);
        GetComponent<SpriteRenderer>().sprite = sprites[directionIndex];
        StartCoroutine(delay2seconds());
    }
}
