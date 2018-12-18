using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private float playerLife;
    [SerializeField] private string mapLevel, thisLevel;
    [SerializeField] private GameObject looseText, winText;
    [SerializeField] private EnemySequence enemySequenceScript;
    [SerializeField] private bool loose;
    [SerializeField] private PlayerMovements player;
    [SerializeField] private GameObject frisbeeKeeper;
    [SerializeField] private GameObject ice, fire, electric, gaz;
    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private int levelID;
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private float money, addedMoney;
    [SerializeField] private float iceCooldown, iceFreezeTime, fireCooldown, electricCooldown, gazCooldown, maxLife;
    public float IceCooldown
    {
        get { return iceCooldown; }
    }
    public float IceFreezeTime
    {
        get { return iceFreezeTime; }
    }
    public float FireCooldown
    {
        get { return fireCooldown; }
    }
    public float ElectricCooldown
    {
        get { return electricCooldown; }
    }
    public float GazCooldown
    {
        get { return gazCooldown; }
    }
    public float MaxLife
    {
        get { return maxLife; }
    }




    private bool callOnce = true;
    
    private void Start()
    {
        mapLevel = "Map";
        levelID += 14;
        frisbeeKeeper = GameObject.FindGameObjectWithTag("FrisbeeKeeper");
        thisLevel = SceneManager.GetActiveScene().name + "_Intro";

        Invoke("GetMoney", 0.1f);

        FrisbeeKeeper fk = frisbeeKeeper.GetComponent<FrisbeeKeeper>();
        

        if (fk.HasIce)
        {
            ice.SetActive(true);
        }
        if (fk.HasFire)
        {
            fire.SetActive(true);
        }
        if (fk.HasElectric)
        {
            electric.SetActive(true);
        }
        if (fk.HasGaz)
        {
            gaz.SetActive(true);
        }

        Invoke("GetStats", 0.1f);
    }

    // Update is called once per frame
    void Update () {

        playerLife = player.Life;

		if(playerLife <= 0 || loose)
        {
            looseText.SetActive(true);
            enemySequenceScript.Stop();
            player.enabled = false;
            enemySequenceScript.enabled = false;
        }

        if(enemySequenceScript.EnemyCount <= 0 && callOnce)
        {
            callOnce = false;
            winText.SetActive(true);
            inventoryScript.ModifyItem(levelID, true);
            inventoryScript.ModifyItem(14, false, money + addedMoney);
            player.enabled = false;
            player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            enemySequenceScript.enabled = false;
        }
	}


    void GetMoney()
    {
        float mon = 0 ;
        bool fooBool;
        inventoryScript.GetItemState(out fooBool, out mon, 14);
        money = mon;
        textMoney.text = "Money : " + money.ToString();
       
    }

    void GetStats()
    {
        bool foobool;
        inventoryScript.GetItemState(out foobool, out iceCooldown, 1);
        inventoryScript.GetItemState(out foobool, out iceFreezeTime, 2);
        enemySequenceScript.FreezeTime = iceFreezeTime;
        inventoryScript.GetItemState(out foobool, out fireCooldown, 4);
        inventoryScript.GetItemState(out foobool, out gazCooldown, 6);
        inventoryScript.GetItemState(out foobool, out electricCooldown, 8);
        inventoryScript.GetItemState(out foobool, out maxLife, 13);
    }

    public void AddMoney(int moneyToAdd) {
        addedMoney += moneyToAdd;
        textMoney.text = "Money : " + (money + addedMoney).ToString() ;

    }

    public void AsLost()
    {
        loose = true;

    }

    public void Retry()
    {
        Time.timeScale = 1;
        Destroy(frisbeeKeeper);
        SceneManager.LoadScene(thisLevel);
    }

    public void ReturnMap()
    {
        Time.timeScale = 1;
        Destroy(frisbeeKeeper);
        SceneManager.LoadScene(mapLevel);
    }
}
