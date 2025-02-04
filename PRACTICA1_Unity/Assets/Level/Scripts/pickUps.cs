using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickUps : MonoBehaviour
{
    public GameManager_V_Script gameManagerV;
    public int minValue;
    public int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerV = FindObjectOfType<GameManager_V_Script>();
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
        gameManagerV.amountMoney = gameManagerV.amountMoney + randomCoinMoney;
    }


}
