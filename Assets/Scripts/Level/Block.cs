﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] private EnemySequence enemySequenceScript;
    [SerializeField] private PosLow posLowScript;

    [SerializeField] private float life;
    private SpriteRenderer spRenderer;

	// Use this for initialization
	void Start () {
        spRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(life <= 0)
        {
            Destroy(gameObject);
        }
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy_Projectile")
        {
            if (posLowScript.IsStuck && life <= 5)
            {
                enemySequenceScript.IsStuck = false;
                posLowScript.IsStuck = false;
                posLowScript.DestroyGM = null;
            }
            Destroy(collision.gameObject);
            LowerLife(5);
        }
    }

    public void LowerLife(int lifeToDecrease)
    {
 
        life -= lifeToDecrease;
        spRenderer.material.color = new Color(1, life / 100, life / 100);

    }
}
