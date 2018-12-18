using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] private JSON_Save jsonSave;

    [SerializeField] private bool ice_Obtained, fire_Obtained, gaz_Obtained, electric_Obtained, shield_Obtained, shield_SendBack;
    [SerializeField] private bool lvl1, lvl2, lvl3, lvl4, lvl5, lvl6, lvl7, lvl8, lvl9, lvl10;
    [SerializeField] private float ice_Cooldown, ice_FreezeTime, fire_Cooldown, gaz_Cooldown, electric_Cooldown, shield_Cooldown, shield_ActiveTime, maxLife, money;

    void Start () {
        jsonSave.ReadJson();
        UpdateInventory(jsonSave.valuesState);
        ModifyItem(14, false, 99999);

    }

    public void ModifyItem(int ID, bool state = default(bool), float value = default(int))
    {
        jsonSave.WriteJson(ID, state, Mathf.Round(value * 10) / 10);
        jsonSave.ReadJson();
        UpdateInventory(jsonSave.valuesState);
    }

    void UpdateInventory(JSON_Save.Values SavedInventory)
    {
        ice_Obtained      = SavedInventory.Ice_Obtained;
        fire_Obtained     = SavedInventory.Fire_Obtained;
        gaz_Obtained      = SavedInventory.Gaz_Obtained;
        electric_Obtained = SavedInventory.Electric_Obtained;
        shield_Obtained   = SavedInventory.Shield_Obtained;
        shield_SendBack   = SavedInventory.Shield_SendBack;

        ice_Cooldown      = SavedInventory.Ice_Cooldown;
        ice_FreezeTime    = SavedInventory.Ice_FreezeTime;
        fire_Cooldown     = SavedInventory.Fire_Cooldown;
        gaz_Cooldown      = SavedInventory.Gaz_Cooldown;
        electric_Cooldown = SavedInventory.Electric_Cooldown;
        shield_Cooldown   = SavedInventory.Shield_Cooldown;
        shield_ActiveTime = SavedInventory.Shield_ActiveTime;

        maxLife           = SavedInventory.MaxLife;
        money             = SavedInventory.Money;

        lvl1              = SavedInventory.lvl1;
        lvl2              = SavedInventory.lvl2;
        lvl3              = SavedInventory.lvl3;
        lvl4              = SavedInventory.lvl4;
        lvl5              = SavedInventory.lvl5;
        lvl6              = SavedInventory.lvl6;
        lvl7              = SavedInventory.lvl7;
        lvl8              = SavedInventory.lvl8;
        lvl9              = SavedInventory.lvl9;
        lvl10             = SavedInventory.lvl10;


    }

    public void GetItemState(out bool state, out float value, int id)
    {
        state = false;
        value = 0;

        switch (id)
        {
            case 0:
                state = ice_Obtained;
                break;

          case 1:
                value = ice_Cooldown;
                break;

            case 2:
                value = ice_FreezeTime;
                break;

            case 3:
                state = fire_Obtained;
                break;

            case 4:
                value = fire_Cooldown;
                break;

            case 5:
                state = gaz_Obtained;
                break;

            case 6:
                value = gaz_Cooldown;
                break;

            case 7:
                state = electric_Obtained;
                break;

            case 8:
                value = electric_Cooldown;
                break;

            case 9:
                state = shield_Obtained;
                break;

            case 10:
                value = shield_Cooldown;
                break;

            case 11:
                value = shield_ActiveTime;
                break;

            case 12:
                state = shield_SendBack;
                break;

            case 13:
                value = maxLife;
                break;

            case 14:
                value = money;
                break;

            case 15:
                state = lvl1;
                break;
            case 16:
                state = lvl2;
                break;
            case 17:
                state = lvl3;
                break;
            case 18:
                state = lvl4;
                break;
            case 19:
                state = lvl5;
                break;
            case 20:
                state = lvl6;
                break;
            case 21:
                state = lvl7;
                break;
            case 22:
                state = lvl8;
                break;
            case 23:
                state = lvl9;
                break;
            case 24:
                state = lvl10;
                break;
        }
    }
}
