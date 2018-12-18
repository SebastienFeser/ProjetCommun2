using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInMap : MonoBehaviour {
    float playerSpeed = 0.1f;



    GameObject up;
    GameObject down;
    GameObject left;
    GameObject right;

    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] Transform lastPosTransform;
    [SerializeField] AudioClip sound;
    [SerializeField] AudioSource source;

    Transform destination;
    private bool isInside;

    private string levelToSelect;
    private bool levelLoader;


    private Vector2 lastPos;
    private int firstStart;
	// Use this for initialization
	void Awake () {
        firstStart = PlayerPrefs.GetInt("FirstStart");

        if (firstStart == 0)
        {
            float x = PlayerPrefs.GetFloat("LastPosX");
            float y = PlayerPrefs.GetFloat("LastPosY");
            transform.position = new Vector2(x, y);
            //lastPosTransform.position = new Vector2(x,y);
        }
        else
        {
            //lastPosTransform.position = transform.position;
            PlayerPrefs.SetFloat("LastPosX", -2.43f);
            PlayerPrefs.SetFloat("LastPosY", 3.93f);
            PlayerPrefs.SetInt("FirstStart", 0);


        }
        transform.position = lastPosTransform.position;
        destination = lastPosTransform;
	}
	
	void Update () {

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination.transform.position, playerSpeed);
        PlayerPrefs.SetFloat("LastPosX", transform.position.x);
        PlayerPrefs.SetFloat("LastPosY", transform.position.y);

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

        if (Input.GetButtonDown("Select") && isInside && levelLoader)
        {
            source.PlayOneShot(sound);
            Invoke("LoadDelay", 0.2f);
        }
    }

    void LoadDelay()
    {
        SceneManager.LoadScene(levelToSelect);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MapPoint")
        {
            isInside = true;
            up = collision.gameObject.GetComponent<MapPoints>().upPoint;
            down = collision.gameObject.GetComponent<MapPoints>().downPoint;
            left = collision.gameObject.GetComponent<MapPoints>().leftPoint;
            right = collision.gameObject.GetComponent<MapPoints>().rightPoint;
            levelToSelect = collision.gameObject.GetComponent<MapPoints>().LevelSelection;
            levelLoader = collision.gameObject.GetComponent<MapPoints>().LevelLoader;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        up = null;
        down = null;
        left = null;
        right = null;
        levelToSelect = "";
    }


}
