using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrisbeeChanger : MonoBehaviour {
    [SerializeField] private GameObject laser;
    private LaserMovements laserMovementScript;
    [SerializeField] private EnemyController.deathType type;
    [SerializeField] private TextMeshProUGUI text;
	void Start () {
        laserMovementScript = laser.GetComponent<LaserMovements>();
	}
	
	public void ModifyType()
    {
        text.text = "Current frisbee : " + type.ToString();
        laserMovementScript.Type = type;
    }
}
