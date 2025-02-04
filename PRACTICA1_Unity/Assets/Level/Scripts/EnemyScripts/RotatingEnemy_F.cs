using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy_F : MonoBehaviour
{
    //Script per decidir el sprite que ha de reproduir l'enemic que rota, per que vagi d'acord amb la llum i trigger box
    public bool Stop = false;
    [SerializeField] Sprite[] sprites; //Array per ficar els sprites
    private int directionIndex = 0;
    IEnumerator delay2seconds()
    {
        if (Stop)
        {
        }
        else
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
        
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(-1, 1);
        GetComponent<SpriteRenderer>().sprite = sprites[directionIndex];
        StartCoroutine(delay2seconds());
    }
}
