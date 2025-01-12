using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Movement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    private bool isMoving;
    public Sprite right;
    public Sprite left;
    public Sprite up;
    public Sprite down;
    private Vector2 input;
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
        if (!isMoving)
        {
            movement();
        }
    }

    public void movement()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            //sprite mirant dreta
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
}
