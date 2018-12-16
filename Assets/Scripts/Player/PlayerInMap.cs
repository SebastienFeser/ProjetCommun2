using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMap : MonoBehaviour {
    [SerializeField] float playerSpeed = 2;

    GameObject up;
    GameObject down;
    GameObject left;
    GameObject right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Left") && left != null)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, left.transform.position, playerSpeed);
        }

        if (Input.GetButtonDown("Right") && right != null)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, right.transform.position, playerSpeed);
        }

        if (Input.GetButtonDown("Up") && up!= null)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, up.transform.position, playerSpeed);
        }

        if (Input.GetButtonDown("Down") && down != null)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, down.transform.position, playerSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MapPoint")
        {
            up = null;
            down = null;
            left = null;
            right = null;
            up = collision.gameObject.GetComponent<MapPoints>().upPoint;
            down = collision.gameObject.GetComponent<MapPoints>().downPoint;
            left = collision.gameObject.GetComponent<MapPoints>().leftPoint;
            right = collision.gameObject.GetComponent<MapPoints>().rightPoint;
        }
    }

    
}
