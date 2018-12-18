using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeKeeper : MonoBehaviour { 
    [SerializeField] private bool hasIce, hasFire, hasElectric, hasGaz;
    public bool HasIce
    {
        get { return hasIce; }
        set { hasIce = value; }
    }
    public bool HasFire
    {
        get { return hasFire; }
        set { hasFire = value; }
    }
    public bool HasElectric
    {
        get { return hasElectric; }
        set { hasElectric = value; }
    }
    public bool HasGaz
    {
        get { return hasGaz; }
        set { hasGaz = value; }
    }

    // Use this for initialization
    private void Awake()
    {
        Time.timeScale = 1;
        DontDestroyOnLoad(this);
    }
}
