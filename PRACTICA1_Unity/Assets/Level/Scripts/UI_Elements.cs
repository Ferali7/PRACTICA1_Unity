using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Elements : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI keysText;
    public int numberKeys = 0;
    public int amountMoney = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = amountMoney.ToString();
        keysText.text = numberKeys.ToString();
    }
    public void AddKey()
    {
        numberKeys++;
    }
    public void AddMoney()
    {
        int randomMoney = Random.Range(300, 500);
        amountMoney = amountMoney + randomMoney;
    }
}
