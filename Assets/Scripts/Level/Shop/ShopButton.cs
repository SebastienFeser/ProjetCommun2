using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private int id;
    [SerializeField] private bool state;
    [SerializeField] private int value;


    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private Toggle toggle;

   

    private void Start()
    {
        Invoke("GetInfo", 0.3f);
    }

    void GetInfo()
    {
        int getValue = 0;
        bool getBool = false;

        inventoryScript.GetItemState(out getBool, out getValue, id);
        toggle.isOn = getBool;
    }

    public void ChangeValue() {
        state = !state;
        inventoryScript.ModifyItem(id, state, value);
        GetInfo();
    }
}
