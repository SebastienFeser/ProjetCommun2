using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class JSON_Save : MonoBehaviour {
    private string json;

    public Values valuesState;

    [Serializable]
    public class Values
    {
        public bool Ice_Obtained;
        public float Ice_Cooldown;
        public float Ice_FreezeTime;

        public bool Fire_Obtained;
        public float Fire_Cooldown;

        public bool Gaz_Obtained;
        public float Gaz_Cooldown;

        public bool Electric_Obtained;
        public float Electric_Cooldown;

        public bool Shield_Obtained;
        public float Shield_Cooldown;
        public float Shield_ActiveTime;
        public bool Shield_SendBack;

        public float MaxLife;
        public float Money;

        public bool lvl1, lvl2, lvl3, lvl4, lvl5, lvl6, lvl7, lvl8, lvl9, lvl10;
    }


    private void Awake()
    {
        if (!System.IO.File.Exists(Application.dataPath + "/Inventory.json"))
        {
            CreateNewJSON();
        }
        valuesState = new Values();
        ReadJson();
    }

    public void WriteJson(int valueToChange, bool state = default(bool), float valueInt = default(float))
    {
        switch (valueToChange)
        {
            case 0:
                JsonUtility.FromJsonOverwrite(json, valuesState.Ice_Obtained);
                valuesState.Ice_Obtained = state;
                break;

            case 1:
                JsonUtility.FromJsonOverwrite(json, valuesState.Ice_Cooldown);
                valuesState.Ice_Cooldown = valueInt;
                break;

            case 2:
                JsonUtility.FromJsonOverwrite(json, valuesState.Ice_FreezeTime);
                valuesState.Ice_FreezeTime = valueInt;
                break;

            case 3:
                JsonUtility.FromJsonOverwrite(json, valuesState.Fire_Obtained);
                valuesState.Fire_Obtained = state;
                break;

            case 4:
                JsonUtility.FromJsonOverwrite(json, valuesState.Fire_Cooldown);
                valuesState.Fire_Cooldown = valueInt;
                break;

            case 5:
                JsonUtility.FromJsonOverwrite(json, valuesState.Gaz_Obtained);
                valuesState.Gaz_Obtained = state;
                break;

            case 6:
                JsonUtility.FromJsonOverwrite(json, valuesState.Gaz_Cooldown);
                valuesState.Gaz_Cooldown = valueInt;
                break;

            case 7:
                JsonUtility.FromJsonOverwrite(json, valuesState.Electric_Obtained);
                valuesState.Electric_Obtained = state;
                break;

            case 8:
                JsonUtility.FromJsonOverwrite(json, valuesState.Electric_Cooldown);
                valuesState.Electric_Cooldown = valueInt;
                break;

            case 9:
                JsonUtility.FromJsonOverwrite(json, valuesState.Shield_Obtained);
                valuesState.Shield_Obtained = state;
                break;

            case 10:
                JsonUtility.FromJsonOverwrite(json, valuesState.Shield_Cooldown);
                valuesState.Shield_Cooldown = valueInt;
                break;

            case 11:
                JsonUtility.FromJsonOverwrite(json, valuesState.Shield_ActiveTime);
                valuesState.Shield_ActiveTime = valueInt;
                break;

            case 12:
                JsonUtility.FromJsonOverwrite(json, valuesState.Shield_SendBack);
                valuesState.Shield_SendBack = state;
                break;

            case 13:
                JsonUtility.FromJsonOverwrite(json, valuesState.MaxLife);
                valuesState.MaxLife = valueInt;
                break;
          
            case 14:
                JsonUtility.FromJsonOverwrite(json, valuesState.Money);
                valuesState.Money = valueInt;
                break;

            case 15:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl1);
                valuesState.lvl1 = state;
                break;
            case 16:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl2);
                valuesState.lvl2 = state;
                break;
            case 17:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl3);
                valuesState.lvl3 = state;
                break;
            case 18:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl4);
                valuesState.lvl4 = state;
                break;
            case 19:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl5);
                valuesState.lvl5 = state;
                break;
            case 20:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl6);
                valuesState.lvl6 = state;
                break;
            case 21:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl7);
                valuesState.lvl7 = state;
                break;
            case 22:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl8);
                valuesState.lvl8 = state;
                break;
            case 23:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl9);
                valuesState.lvl9 = state;
                break;
            case 24:
                JsonUtility.FromJsonOverwrite(json, valuesState.lvl10);
                valuesState.lvl10 = state;
                break;
        }

        json = JsonUtility.ToJson(valuesState);

        File.WriteAllText(Application.dataPath + "/Inventory.json", json);

       /* #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif*/

    }

    public void ReadJson()
    {
        json = File.ReadAllText(Application.dataPath + "/Inventory.json");
        valuesState = JsonUtility.FromJson<Values>(json);
    }

    void CreateNewJSON()
    {
        WriteJson(0, false, 0); //Ice Obtained
        WriteJson(1, false, 5); //Ice Cooldown
        WriteJson(2, false, 2); //Ice freezetime

        WriteJson(3, false, 0); //Fire obtained
        WriteJson(4, false, 5); //fire cooldown

        WriteJson(5, false, 0); //gaz obtained
        WriteJson(6, false, 5); //gaz cooldown

        WriteJson(7, false, 0); //electric obtained
        WriteJson(8, false, 5); //electric cooldown

        WriteJson(9, false, 0); //shield obtained
        WriteJson(10, false, 0); //shield cooldown
        WriteJson(11, false, 0); //shield active time
        WriteJson(12, false, 0); //shield sendback

        WriteJson(13, false, 100); //Max life
        WriteJson(14, false, 0); //Money


    }
}
