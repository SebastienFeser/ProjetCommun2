using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetMoney : MonoBehaviour {
    [SerializeField] private Inventory inventoryScript;

    private TextMeshProUGUI text;
	void Start () {
        text = GetComponent<TextMeshProUGUI>();
	}
	
	void Update () {
        float money;
        bool foobool;

        inventoryScript.GetItemState(out foobool, out money, 14);
        text.text ="Money : " + money.ToString();
	}
}
