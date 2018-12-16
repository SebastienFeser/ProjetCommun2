using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeSelector : MonoBehaviour {
    [SerializeField] private GameObject ice, fire, electric, gaz;
    [SerializeField] private Inventory inventoryScript;

    private bool hasIce, hasFire, hasElectric, hasGaz;

	// Use this for initialization
	void Start () {
        int valuefoo = 0;
        inventoryScript.GetItemState(out hasIce, out valuefoo, 0);
        inventoryScript.GetItemState(out hasFire, out valuefoo, 3);
        inventoryScript.GetItemState(out hasGaz, out valuefoo, 5);
        inventoryScript.GetItemState(out hasElectric, out valuefoo, 7);

        ice.SetActive(hasIce);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
