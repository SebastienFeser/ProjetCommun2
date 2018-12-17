using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosLow : MonoBehaviour {
    [SerializeField] private EnemySequence enemySequenceScript;
    [SerializeField] private bool isStuck;
    public bool IsStuck
    {
        get { return isStuck; }
        set { isStuck = value; }
    }
    [SerializeField] private GameObject destroyGM;
    public GameObject DestroyGM
    {
        get { return destroyGM; }
        set { destroyGM = value; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            isStuck = true;
            destroyGM = collision.gameObject;
        }
    }
}
