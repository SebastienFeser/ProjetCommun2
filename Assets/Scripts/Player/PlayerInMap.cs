using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMap : MonoBehaviour {
    float playerSpeed = 0.1f;



    GameObject up;
    GameObject down;
    GameObject left;
    GameObject right;

    [SerializeField] Rigidbody2D playerRigidBody;

    Transform destination;

    public int levelToSelect;

	// Use this for initialization
	void Start () {
        destination = transform;
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination.transform.position, playerSpeed);


        if (playerRigidBody.velocity.magnitude < 0.1f)
        {
            if (Input.GetButtonDown("Left") && left != null)
            {
                destination = left.transform;
            }

            if (Input.GetButtonDown("Right") && right != null)
            {
                destination = right.transform;
            }

            if (Input.GetButtonDown("Up") && up != null)
            {
                destination = up.transform;
            }

            if (Input.GetButtonDown("Down") && down != null)
            {
                destination = down.transform;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            switch (levelToSelect)
            {
                case 0:
                    break;
                case 1:
                    //Load Level 1
                    break;
                case 2:
                    //Load Level 2
                    break;
                case 3:
                    //Load Level 3
                    break;
                case 4:
                    //Load Level 4
                    break;
                case 5:
                    //Load Level 5
                    break;
                case 6:
                    //Load Level 6
                    break;
                case 7:
                    //Load Level 7
                    break;
                case 8:
                    //Load Level 8
                    break;
                case 9:
                    //Load Level 9
                    break;
                case 10:
                    //Load Level 10
                    break;
                case 31:
                    //Load Shop 1
                    break;
                case 32:
                    //Load Shop 2
                    break;
                case 33:
                    //Load Shop 3
                    break;
                default:
                    break;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MapPoint")
        {
            
            up = collision.gameObject.GetComponent<MapPoints>().upPoint;
            down = collision.gameObject.GetComponent<MapPoints>().downPoint;
            left = collision.gameObject.GetComponent<MapPoints>().leftPoint;
            right = collision.gameObject.GetComponent<MapPoints>().rightPoint;
            levelToSelect = collision.gameObject.GetComponent<MapPoints>().levelSelection;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        up = null;
        down = null;
        left = null;
        right = null;
        levelToSelect = 0;
    }


}
