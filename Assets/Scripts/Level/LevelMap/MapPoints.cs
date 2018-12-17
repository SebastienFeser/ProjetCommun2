using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoints : MonoBehaviour {

    [SerializeField] GameObject player;

    [SerializeField] public GameObject leftPoint;
    [SerializeField] public GameObject rightPoint;
    [SerializeField] public GameObject upPoint;
    [SerializeField] public GameObject downPoint;

    [SerializeField] bool canMoveUp = true;
    [SerializeField] bool canMoveDown = true;
    [SerializeField] bool canMoveLeft = true;
    [SerializeField] bool canMoveRight = true;

    [SerializeField] public int levelSelection;

    bool canMove = true;
    bool levelPassed = false;
    
	void Start () {
        // if levelPassed, all can move = true

        if (!canMoveUp)
            upPoint = null;
        if (!canMoveDown)
            downPoint = null;
        if (!canMoveLeft)
            leftPoint = null;
        if (!canMoveRight)
            rightPoint = null;
	}
	
	void Update () {

	}

    
}
