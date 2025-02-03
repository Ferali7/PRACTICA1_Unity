using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickUps : MonoBehaviour
{
    public GameManager_Script gameManager;
    public int minValue;
    public int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddMoney();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMoney()
    {
        int randomCoinMoney = Random.Range(minValue, maxValue);
        gameManager.amountMoney = gameManager.amountMoney + randomCoinMoney;
    }


}
