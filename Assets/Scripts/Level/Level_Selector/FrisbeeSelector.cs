using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrisbeeSelector : MonoBehaviour {
    [SerializeField] private GameObject ice, fire, electric, gaz;
    [SerializeField] private Toggle toggleIce, toggleFire, toggleElectric, toggleGaz;
    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private FrisbeeKeeper frisbeeKeeperScript;
    [SerializeField] private Toggle[] toggleGroup;
    [SerializeField] private bool canSelect = true;
    public bool CanSelect
    {
        get{ return canSelect; }
    }


    private bool hasIce, hasFire, hasElectric, hasGaz;
    private int maxFrisbee = 2;
    public int currentFrisbeeCount;

    // Use this for initialization
    void Start() {
        int valuefoo = 0;
        inventoryScript.GetItemState(out hasIce, out valuefoo, 0);
        inventoryScript.GetItemState(out hasFire, out valuefoo, 3);
        inventoryScript.GetItemState(out hasGaz, out valuefoo, 5);
        inventoryScript.GetItemState(out hasElectric, out valuefoo, 7);

        ice.SetActive(hasIce);
        fire.SetActive(hasFire);
        electric.SetActive(hasElectric);
        gaz.SetActive(hasGaz);

    }

    private void Update()
    {
        canSelect = !(currentFrisbeeCount >= maxFrisbee);

        if (!CanSelect)
        {
            foreach (Toggle tog in toggleGroup)
            {
                if (!tog.isOn)
                {
                    tog.interactable = false;
                }
            }
        }
        else
        {
            foreach (Toggle tog in toggleGroup)
            {
              tog.interactable = true;
               
            }
        }
    }

    public void RegIce()
    {
        if (toggleIce.isOn)
        {
            if (canSelect)
            {
                frisbeeKeeperScript.HasIce = true;
                currentFrisbeeCount++;
            }
        }
        else
        {
            currentFrisbeeCount--;
            frisbeeKeeperScript.HasIce = false;
        }
    }

    public void RegFire()
    {
        if (toggleFire.isOn)
        {
            if (canSelect)
            {
                currentFrisbeeCount++;
                frisbeeKeeperScript.HasFire = true;
            }
        }
        else {
            currentFrisbeeCount--;
            frisbeeKeeperScript.HasFire = false;
        }
    }

    public void RegElectric()
    {
        if (toggleElectric.isOn)
        {
            if (canSelect)
            {
                currentFrisbeeCount++;
                frisbeeKeeperScript.HasElectric = true;
            }
        }
        else
        {
            currentFrisbeeCount--;
            frisbeeKeeperScript.HasElectric = false;
        }
    }

    public void RegGaz()
    {
        if (toggleGaz.isOn)
        {
            currentFrisbeeCount++;
            frisbeeKeeperScript.HasGaz = true;
        }
        else
        {
            currentFrisbeeCount--;
            frisbeeKeeperScript.HasGaz = false;
        }
    }

}
