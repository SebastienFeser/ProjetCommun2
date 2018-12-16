using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosLow : MonoBehaviour {

    [SerializeField] private bool isStuck;
    public bool IsStuck
    {
        get { return isStuck; }
    }
    [SerializeField] private GameObject destroyGM;
    public GameObject DestroyGM
    {
        get { return destroyGM; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            isStuck = true;
            destroyGM = collision.gameObject;
        }
    }
}
