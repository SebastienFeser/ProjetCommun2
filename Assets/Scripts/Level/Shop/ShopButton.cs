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
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource source;
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
    [SerializeField] private bool noMaster;

    [Header("Frisbee Upgrade")]
    [SerializeField] private int master_id;
    [SerializeField] private float modifyTo;
    [SerializeField] private float minUpgradeValue = 1.0f;
    [SerializeField] private bool increased;

    [Header("Frisbee Unlock")]
    [SerializeField] private bool state = true;



    private float currentMoney;
    private float currentPropertyValue;
    private bool maxedUpgrade;
    private bool canUpgrade;

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

    private void Update()
    {
        float fooval;
        if (!noMaster)
        {
            inventoryScript.GetItemState(out canUpgrade, out fooval, master_id);

            GetComponent<Button>().interactable = canUpgrade;
        }
    }

    void GetMoney()
    {
        bool getBool = false;
        inventoryScript.GetItemState(out getBool, out currentMoney, 14);
    }

    void GetInfo()
    {
        float getValue = 0;
        bool getBool = false;

        inventoryScript.GetItemState(out getBool, out getValue, id);
        if (isUpgradable)
        {
            currentPropertyValue = getValue;

            bool increaseOP;

            if (!increased)
            {
                increaseOP = currentPropertyValue > minUpgradeValue;
            }
            else
            {
                increaseOP = currentPropertyValue < minUpgradeValue;
            }

            if(increaseOP) {
                propertyText.text = "Current : " + currentPropertyValue.ToString() + "\n" + "Next : " + (currentPropertyValue + modifyTo).ToString();

            }
            else
            {
                propertyText.text = "Current : " + currentPropertyValue.ToString() + "\n" + "Next : MAX ";
                maxedUpgrade = true;
            }
        }
        else
        {
            lockState.isOn = getBool;
        }

        if ((lockState.isOn && isUnlockable) || maxedUpgrade)
        {
            GetComponent<Button>().interactable = false;
        }


        GetMoney();
    }

    public void BuyFrisbee() {

        if (price < currentMoney && !maxedUpgrade)
        {
            source.PlayOneShot(sound);
            inventoryScript.ModifyItem(14, false, currentMoney - price);
            inventoryScript.ModifyItem(id, state, currentPropertyValue + modifyTo);
            GetInfo();
        }

        GetMoney();
    }

    void check()
    {
        GetInfo();
    }
}
