using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickUps : MonoBehaviour
{
    //script que controla la suma de diners al recollir un objecte del terra com pot ser moneda o lingot d'or
    //referenciem el script que conté les variables gameManager_Variables
    public GameManager_V_Script gameManagerV;
    public int minValue;
    public int maxValue;
    AudioManager audioManager;

    void Awake()
    {
        //ens servirà per trobar l'objecte AudioManager a l'escena que s'encarrega de deixarli fer play al so.
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddMoney();
        audioManager.PlaySFX(audioManager.moneyCollected);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //funció AddMoney separada de la que es troba al gameManagerV, ja que aquella controla la quantitat que suma als diners una  caixa forta que s'obre (valor random entre 300 i 500), i aquesta al ser per pickups més petits l'hem deixat definida a part. els valors es troben serialitzats a l'inspector dels pickups
    public void AddMoney()
    {
        int randomCoinMoney = Random.Range(minValue, maxValue);
        gameManagerV.amountMoney = gameManagerV.amountMoney + randomCoinMoney;
    }


}
