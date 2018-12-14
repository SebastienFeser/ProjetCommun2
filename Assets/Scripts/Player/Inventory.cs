using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
NOTE

    J'ai pas mis les bool dans une liste pour qu'on puisse avoir un glossaire dans la région "Booleans for Shop items"

*/
public class Inventory : MonoBehaviour {
    float life;
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
    bool item9;                     //Gaz range++
    bool item10;                    //Cooldown all fris --                      DONE
    bool item11;                    //More life
    bool item12;                    //Electric fris explode armored bees
    bool itemBONUS;                 //Frisbe shield                             DONE
    #endregion

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (item1)
        {
            hasElec = true;
            item1 = false;
        }

        if (item2)
        {
            hasGaz = true;
            item2 = false;
        }

        if (item3)
        {
            coolDownNormal = coolDownNormal / 2;
            item3 = false;
        }

        if (item4)
        {
            shieldEffectTime *= 2;
            item4 = false;
        }

        if (item5)
        {
            hasFire = true;
            item5 = false;
        }

        if (item6)
        {
            hasIce = true;
            item6 = false;
        }

        if (item7)
        {
            shieldMirroring = true;
            item7 = false;
        }

        if (item8)
        {
            freezeTime *= 2;
            item8 = false;
        }

        if (item9)
        {
            item9 = false;
        }

        if (item10)
        {
            coolDownNormal = coolDownNormal / 2;
            coolDownElec = coolDownElec / 2;
            coolDownGaz = coolDownGaz / 2;
            coolDownFire = coolDownFire / 2;
            coolDownIce = coolDownIce / 2;
            coolDownShield = coolDownShield / 2;
            item10 = false;
        }

        if (item11)
        {
            life += lifeAugmentation;
            item11 = false;
        }

        if (item12)
        {
            item12 = false;
        }

        if (itemBONUS)
        {
            hasShield = true;
            itemBONUS = false;
        }
    }
}
