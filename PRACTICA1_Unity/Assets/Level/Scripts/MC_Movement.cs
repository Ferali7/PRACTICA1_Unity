using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Movement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    private Vector2 movement;
    Rigidbody2D rb;
    Animator animator;
    //utilitzarem aixo per ferli flip a la tecla E que es mostra, que s'invertiria al mirar a l'esquerra
    public Transform canvasTransform;
    // Start is called before the first frame update
    void Start()
    {
        //per trobar el canvas que cal invertir quan mirem a l'esquerra
        canvasTransform = GameObject.Find("TeclaE").transform;
        rb = GetComponent<Rigidbody2D>();
        print("---" + rb.name);
        animator = GetComponent<Animator>();
        //print("start");
        //inicialitzaci� de les variables de la m�quina d'estats com a falses excepte la de idle, tot i que no seria necessari al ser la animaci� per default a inici
        animator.SetBool("notWalking", true);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingTop", false);
        animator.SetBool("walkingBottom", false);
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
        //funcions previament realitzades abans d'utilitzar la m�quina d'estats
        //isMoving();
        //isMovingDiagonal();
        movementStates();
    }
    //ismoving() i ismovingdiagonal(), ja no utilitzats
    /*
    public void isMoving()
    {
        //funci� que determina el sprite que es mostra dependent de en quina direcci� es mou
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
        //funci� que determina el sprite que es mostra dependent de en quina direcci� es mou
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
    */
    //movementStates() es la m�quina d'estats que hem designat per les animacions d'idle, moviment dreta esquerra i adalt abaix
    public void movementStates()
    {
        if (movement.x > 0)
        {
            animator.SetBool("walkingRight", true);
            animator.SetBool("walkingTop", false);
            animator.SetBool("walkingBottom", false);
            animator.SetBool("notWalking", false);
            transform.localScale = new Vector2(1, 1);
            //tornar el canvas Tecla E a la orientaci� normal
            canvasTransform.localScale = new Vector2(1, 1);
        }
        if (movement.x < 0)
        {
            animator.SetBool("walkingRight", true);
            animator.SetBool("walkingTop", false);
            animator.SetBool("walkingBottom", false);
            animator.SetBool("notWalking", false);
            transform.localScale = new Vector2(-1, 1);
            //canviar el canvas Tecla E d'orientaci� si el personatge mira cap a l'esquerra, ja que al ser fill tamb� s'inverteix, per� volem que el canvas es mantingui, per aix� l'invertim
            canvasTransform.localScale = new Vector2(-1, 1);
        }
        if (movement.y > 0)
        {
            animator.SetBool("walkingRight", false);
            animator.SetBool("walkingTop", true);
            animator.SetBool("walkingBottom", false);
            animator.SetBool("notWalking", false);
        }
        if (movement.y < 0)
        {
            animator.SetBool("walkingRight", false);
            animator.SetBool("walkingTop", false);
            animator.SetBool("walkingBottom", true);
            animator.SetBool("notWalking", false);
        }
        if (movement.x == 0 && movement.y == 0)
        {
            animator.SetBool("walkingRight", false);
            animator.SetBool("walkingTop", false);
            animator.SetBool("walkingBottom", false);
            animator.SetBool("notWalking", true);
        }
    }
}