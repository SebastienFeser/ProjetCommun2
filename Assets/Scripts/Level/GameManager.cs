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
    [SerializeField] private int money, addedMoney;

    private bool callOnce = true;

    private void Start()
    {
        levelID += 14;
        frisbeeKeeper = GameObject.FindGameObjectWithTag("FrisbeeKeeper");
        thisLevel = SceneManager.GetActiveScene().name + "_Intro";

        bool fooBool;
        inventoryScript.GetItemState(out fooBool, out money, 14);
        textMoney.text = "Money : " + money.ToString();
        Debug.Log(money);

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
        }

        if(enemySequenceScript.EnemyCount <= 0 && callOnce)
        {
            callOnce = false;
            winText.SetActive(true);
            inventoryScript.ModifyItem(levelID, true);
        }
	}


    public void AddMoney(int moneyToAdd) {
        addedMoney += moneyToAdd;
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
