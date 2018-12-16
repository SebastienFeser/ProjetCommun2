using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMap : MonoBehaviour {
    [SerializeField] float playerSpeed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "MapPoint")
        {
            Debug.Log("test");
            if (Input.GetButtonDown("Left") && collision.gameObject.GetComponent<MapPoints>().leftPoint != null)
            {
                gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, collision.gameObject.GetComponent<MapPoints>().leftPoint.transform.position, playerSpeed);
            }

            if (Input.GetButtonDown("Right") && collision.gameObject.GetComponent<MapPoints>().rightPoint != null)
            {
                gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, collision.gameObject.GetComponent<MapPoints>().rightPoint.transform.position, playerSpeed);
            }

            if (Input.GetButtonDown("Up") && collision.gameObject.GetComponent<MapPoints>().upPoint != null)
            {
                gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, collision.gameObject.GetComponent<MapPoints>().upPoint.transform.position, playerSpeed);
            }

            if (Input.GetButtonDown("Down") && collision.gameObject.GetComponent<MapPoints>().downPoint != null)
            {
                gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, collision.gameObject.GetComponent<MapPoints>().downPoint.transform.position, playerSpeed);
            }
        }
    }
}
