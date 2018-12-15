using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] private JSON_Save jsonSave;
    /*float life;
    float lifeAugmentation = 50;

    float freezeTime;
    float shieldEffectTime;

    bool shieldMirroring = false;   //Send back projectiles

    #region Has Frisbe
    bool hasIce = false;
    bool hasFire = false;
    bool hasElec = false;
    bool hasGaz = false;
    bool hasShield = false;
    #endregion

    #region Frisbe cooldown
    float coolDownNormal;
    float coolDownElec;
    float coolDownGaz;
    float coolDownFire;
    float coolDownIce;
    float coolDownShield;

    public float CoolDownNormal
    {
        get
        {
            return coolDownNormal;
        }
    }

    public float CoolDownElec
    {
        get
        {
            return coolDownElec;
        }
    }

    public float CoolDownGaz
    {
        get
        {
            return coolDownGaz;
        }
    }

    public float CoolDownFire
    {
        get
        {
            return coolDownFire;
        }
    }

    public float CoolDownIce
    {
        get
        {
            return coolDownIce;
        }
    }

    public float CoolDownShield
    {
        get
        {
            return coolDownShield;
        }
    }
    #endregion

    #region Bolleans for Shop items
    bool item1;                     //Frisbe elec                               DONE
    bool item2;                     //Frisbe gaz                                DONE
    bool item3;                     //Cooldown fris normal reduction            DONE
    bool item4;                     //Shield activated time++                   DONE
    bool item5;                     //Frisbe fire                               DONE
    bool item6;                     //Frisbe ice                                DONE
    bool item7;                     //Shield send back projectiles              DONE
    bool item8;                     //Ice slow time++                           DONE
    bool item9;                     //Gaz range++ //NOPE
    bool item10;                    //Cooldown all fris --                      DONE
    bool item11;                    //More life
    bool item12;                    //Electric fris explode armored bees
    bool itemBONUS;                 //Frisbe shield                             DONE
    #endregion*/

    [SerializeField] private bool ice_Obtained, fire_Obtained, gaz_Obtained, electric_Obtained, shield_Obtained, shield_SendBack;
    [SerializeField] private int ice_Cooldown, ice_FreezeTime, fire_Cooldown, gaz_Cooldown, electric_Cooldown, shield_Cooldown, shield_ActiveTime, maxLife, money;

    void Start () {
        jsonSave.ReadJson();
        UpdateInventory(jsonSave.valuesState);
    }

    public void ModifyItem(int ID, bool state = default(bool), int value = default(int))
    {
        jsonSave.WriteJson(ID, state, value);
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
    }

    public void GetItemState(out bool state, out int value, int id)
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
        }
    }
}
