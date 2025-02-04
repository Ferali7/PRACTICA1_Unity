using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickUps : MonoBehaviour
{
    public GameManager_V_Script gameManagerV;
    public int minValue;
    public int maxValue;
    AudioManager audioManager;

    void Awake()
    {
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
    public void AddMoney()
    {
        int randomCoinMoney = Random.Range(minValue, maxValue);
        gameManagerV.amountMoney = gameManagerV.amountMoney + randomCoinMoney;
    }


}
