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

    private bool callOnce = true;
    
    private void Start()
    {
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
        Destroy(frisbeeKeeper);
        SceneManager.LoadScene(thisLevel);
    }

    public void ReturnMap()
    {
        Destroy(frisbeeKeeper);
        SceneManager.LoadScene(mapLevel);
    }
}
