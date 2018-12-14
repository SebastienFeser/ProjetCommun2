using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
NOTE

    J'ai pas mis les bool dans une liste pour qu'on puisse avoir un glossaire dans la région "Booleans for Shop items"

*/
public class Inventory : MonoBehaviour {
    float life;

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
    bool item1;                     //Frisbe elec
    bool item2;                     //Frisbe gaz
    bool item3;                     //Cooldown fris normal reduction            DONE
    bool item4;                     //Shield activated time++
    bool item5;                     //Frisbe fire
    bool item6;                     //Frisbe ice
    bool item7;                     //Shield send back projectiles
    bool item8;                     //Ice slow time++
    bool item9;                     //Gaz range++
    bool item10;                    //Cooldown all fris --
    bool item11;                    //More life
    bool item12;                    //Electric fris explode armored bees
    bool itemBONUS;                 //Frisbe shield
    #endregion

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (item1)
        {
            item1 = false;
        }

        if (item2)
        {
            item2 = false;
        }

        if (item3)
        {
            coolDownNormal = coolDownNormal / 2;
            item3 = false;
        }

        if (item4)
        {
            item4 = false;
        }

        if (item5)
        {
            item5 = false;
        }

        if (item6)
        {
            item6 = false;
        }

        if (item7)
        {
            item7 = false;
        }

        if (item8)
        {
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
            item11 = false;
        }

        if (item12)
        {
            item12 = false;
        }

        if (itemBONUS)
        {
            itemBONUS = false;
        }
    }
}
