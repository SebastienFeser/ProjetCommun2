using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ResetJSON : MonoBehaviour {

    [SerializeField] private Inventory inventoryScript;

    public void ResetJson()
    {
        PlayerPrefs.DeleteAll();
        if (System.IO.File.Exists(Application.dataPath + "/Inventory.json"))
        {
            File.Delete(Application.dataPath + "/Inventory.json");
        }

    }
}
