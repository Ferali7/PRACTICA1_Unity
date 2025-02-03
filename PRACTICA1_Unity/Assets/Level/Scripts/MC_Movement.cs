using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Movement : MonoBehaviour
{
    public GameManager_Script gameManager;
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
        canvasTransform = GameObject.Find("CanvasTeclas").transform;
        //per trobar el script del GameManager i poder dirli que no es mourà a no ser que isPaused sigui falsa
        gameManager = FindObjectOfType<GameManager_Script>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //inicialització de les variables de la màquina d'estats com a falses excepte la de idle
        animator.SetBool("notWalking", true);
        animator.SetBool("walkingRight", false);
        animator.SetBool("walkingTop", false);
        animator.SetBool("walkingBottom", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPaused == false)
        {
            //input del jugador
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(movement.x, movement.y) * speed;
            movementStates();
        }

    }
    //movementStates() es la màquina d'estats que hem designat per les animacions d'idle, moviment dreta esquerra i adalt abaix
    public void movementStates()
    {
        if (movement.x > 0)
        {
            animator.SetBool("walkingRight", true);
            animator.SetBool("walkingTop", false);
            animator.SetBool("walkingBottom", false);
            animator.SetBool("notWalking", false);
            transform.localScale = new Vector2(1, 1);
            //tornar el canvas Tecla E a la orientació normal
            canvasTransform.localScale = new Vector2(1, 1);
        }
        if (movement.x < 0)
        {
            animator.SetBool("walkingRight", true);
            animator.SetBool("walkingTop", false);
            animator.SetBool("walkingBottom", false);
            animator.SetBool("notWalking", false);
            transform.localScale = new Vector2(-1, 1);
            //canviar el canvas Tecla E d'orientació si el personatge mira cap a l'esquerra, ja que al ser fill també s'inverteix, però volem que el canvas es mantingui, per això l'invertim
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