using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FrisbeeChanger : MonoBehaviour {
    [SerializeField] private GameObject laser;
    private LaserMovements laserMovementScript;
    [SerializeField] private EnemyController.deathType type;
    [SerializeField] private Image imageCurrent;
    [SerializeField] private Sprite normal, ice, fire, electric, gaz;

	void Start () {
        laserMovementScript = laser.GetComponent<LaserMovements>();
	}
	
	public void ModifyType()
    {
        switch (type)
        {
            case EnemyController.deathType.normal:
                imageCurrent.sprite = normal;
                break;

            case EnemyController.deathType.ice:
                imageCurrent.sprite = ice;
                break;

            case EnemyController.deathType.fire:
                imageCurrent.sprite = fire;
                break;

            case EnemyController.deathType.electric:
                imageCurrent.sprite = normal;
                break;

            case EnemyController.deathType.gaz:
                imageCurrent.sprite = gaz;
                break;
        }
        laserMovementScript.Type = type;
    }
}
