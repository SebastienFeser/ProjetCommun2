using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour {
    [Help("ID's " +
        "\n 0 : Ice_Obtained " +
        "\n 1: Ice_Cooldown " +
        "\n 2: Ice_FreezeTime" +
        "\n" +
        "\n 3: Fire_Obtained" +
        "\n 4: Fire_Cooldown" +
        "\n" +
        "\n 5 Gaz_Obtained" +
        "\n 6: Gaz_Cooldown" +
        "\n" +
        "\n 7: Electric_Obtained" +
        "\n 8: Electric_Cooldown" +
        "\n" +
        "\n 9: Shield_Obtained" +
        "\n 10: Shield_Cooldown" +
        "\n 11: Shield_ActiveTime" +
        "\n 12: Shield_SendBack" +
        "\n" +
        "\n 13: MaxLife" +
        "\n 14: Money")]
    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private Toggle lockState;
    [SerializeField] private TextMeshProUGUI propertyText;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Configurator")]
    [SerializeField] private bool isUnlockable;
    [SerializeField] private bool isUpgradable;
    [SerializeField] private int price;

    [Header("Property ID")]
    [SerializeField] private int id;

    [Header("Frisbee Upgrade")]
    [SerializeField] private int increaseBy;

    [Header("Frisbee Unlock")]
    [SerializeField] private bool state = true;



    private int currentMoney;
    private int currentPropertyValue;
   

    private void Start()
    {
        InvokeRepeating("check", 0, 1);
        if (isUpgradable)
        {
            propertyText.gameObject.SetActive(true);
        }
        else
        {
            lockState.gameObject.SetActive(true);
        }

        Invoke("GetInfo", 0.3f);
        priceText.text = "Price : " + price;

    }

    void GetMoney()
    {
        bool getBool = false;
        inventoryScript.GetItemState(out getBool, out currentMoney, 14);
    }

    void GetInfo()
    {
        int getValue = 0;
        bool getBool = false;

        inventoryScript.GetItemState(out getBool, out getValue, id);
        if (isUpgradable)
        {
            currentPropertyValue = getValue;
            propertyText.text = "Value : " + currentPropertyValue.ToString();
        }
        else
        {
            lockState.isOn = getBool;
        }

        GetMoney();
    }

    public void BuyFrisbee() {
        if (price < currentMoney)
        {
            inventoryScript.ModifyItem(14, false, currentMoney - price);
            inventoryScript.ModifyItem(id, state, increaseBy);
            GetInfo();
        }

        GetMoney();
    }

    public void ResetJSON()
    {
        for(int i = 0; i < 14; i++)
        {
            inventoryScript.ModifyItem(i, false, 0);
        }
        inventoryScript.ModifyItem(14, false, 2500); //SET money
    }

    void check()
    {
        GetInfo();
    }
}
