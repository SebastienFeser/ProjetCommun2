using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLoose : MonoBehaviour {

    [SerializeField] private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameManager.AsLost();
            
        }
    }
}
