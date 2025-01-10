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
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            //sprite mirant dreta
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
            //moviment dreta
            //input.x = (1);
            //transform.position = gameObject.GetComponent.location;
            
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
