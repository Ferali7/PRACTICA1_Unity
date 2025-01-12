using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Movement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    public Sprite right;
    public Sprite left;
    public Sprite up;
    public Sprite down;
    private Vector2 movement;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        print("start");
    }

    // Update is called once per frame
    void Update()
    {

        //input del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //prevenim moviment en diagonal prioritzant un eix sobre l'altre
        /*if (movement.x != 0)
        {
            movement.y = 0;
        }
        else if (movement.y != 0)
        {
            movement.x = 0;
        }*/
        rb.velocity = new Vector2(movement.x, movement.y) * speed;
        isMoving();
        //isMovingDiagonal();
    }

    public void isMoving()
    {
        //funció que determina el sprite que es mostra dependent de en quina direcció es mou
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = up;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = down;
        }
    }
    public void isMovingDiagonal()
    {
        //funció que determina el sprite que es mostra dependent de en quina direcció es mou
        if (movement.x > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }
        if (movement.x < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
        }
        if (movement.y > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = up;
        }
        if (movement.y < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = down;
        }
    }
}
