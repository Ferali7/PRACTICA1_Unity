using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class EnemyDetection : MonoBehaviour
{
    public GameManager_Script GameManager;
    private GameObject player;
    private bool InSight;
    private bool InLight = false;
    AudioManager audioManager;
    public Light2D myLight;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameManager = GameObject.FindObjectOfType<GameManager_Script>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator caughtDelay()
    {

        yield return new WaitForSeconds(2.0f);
        GameManager.caught = true;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InLight = true;
            if (InSight && InLight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                print("Detected!!");
                audioManager.PlaySFX(audioManager.caught);
                myLight.color = new Color(255, 0, 0, 50f);
                myLight.falloffIntensity = 0f;
                myLight.shapeLightFalloffSize = 0f;
                GameManager.caught = true;
                //StartCoroutine(caughtDelay());
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InLight = false;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            InSight = ray.collider.CompareTag("Player");
            
        }
    }
}
