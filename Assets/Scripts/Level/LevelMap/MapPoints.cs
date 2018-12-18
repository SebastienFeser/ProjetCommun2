using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MapPoints : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] Inventory inventoryScript;
    [SerializeField] int levelID;

    [SerializeField] public GameObject leftPoint;
    [SerializeField] public GameObject rightPoint;
    [SerializeField] public GameObject upPoint;
    [SerializeField] public GameObject downPoint;

    [SerializeField] bool canMoveUp = true;
    [SerializeField] bool canMoveDown = true;
    [SerializeField] bool canMoveLeft = true;
    [SerializeField] bool canMoveRight = true;

    [SerializeField] bool upDir = false;
    [SerializeField] bool downDir = false;
    [SerializeField] bool leftDir = false;
    [SerializeField] bool rightDir = false;

    [SerializeField] private string levelSelection;
    public string LevelSelection
    {
        get { return levelSelection; }
    }


    [SerializeField] bool levelLoader;
    public bool LevelLoader
    {
        get { return levelLoader; }
    }
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private MapPoints previousLevel;
    bool canMove = true;
    public bool levelPassed = false;

    [SerializeField] private bool isShop;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.DrawLine(new Vector2(transform.position.x - 0.5f, transform.position.y), new Vector2(transform.position.x + 0.5f, transform.position.y));
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + 0.5f), new Vector2(transform.position.x, transform.position.y - 0.5f));

    }

    void Start () {

        if (isShop)
        {
            levelSelection = "Shop";
            levelPassed = true;
        }

        if (levelLoader && !isShop)
        {
            levelText = GameObject.Find(levelID.ToString()).GetComponent<TextMeshProUGUI>();
            levelText.text = levelID.ToString();

            levelSelection = "Level_" + levelID + "_Intro";
            Invoke("GetLevel", 0.2f);
        }
        
	}
	
	void Update () {

	}

    void GetLevel()
    {

        levelID += 14;
        float fooVal;
        inventoryScript.GetItemState(out levelPassed, out fooVal, levelID);

        if (leftDir && !levelPassed) {
            canMoveLeft = false;
        }

        if (upDir && !levelPassed)
        {
            canMoveUp = false;
        }

        if (downDir && !levelPassed)
        {
            canMoveDown = false;
        }

        if (rightDir && !levelPassed)
        {
            canMoveRight = false;
        }

        if (!canMoveUp)
            upPoint = null;
        if (!canMoveDown)
            downPoint = null;
        if (!canMoveLeft)
            leftPoint = null;
        if (!canMoveRight)
            rightPoint = null;

        Invoke("GetPreviousLevel", 0.1f);

    }
    


    void GetPreviousLevel()
    {


        if (levelPassed)
        {
            levelText.color = Color.green;
        }
        else if (!levelPassed && levelID - 14 == 1)
        {
            levelText.color = Color.blue;

        }
        else if (!levelPassed && previousLevel.levelPassed)
        {
            levelText.color = Color.blue;
        }
        else if (!levelPassed)
        {
            levelText.color = Color.red;
        }
    }

}
