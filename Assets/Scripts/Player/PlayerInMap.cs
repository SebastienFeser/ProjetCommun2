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
	void Awake () {
        Time.timeScale = 1;
        firstStart = PlayerPrefs.GetInt("FirstStart");
        float x = PlayerPrefs.GetFloat("LastPosX");
        float y = PlayerPrefs.GetFloat("LastPosY");

        if (firstStart == 0)
        {
            PlayerPrefs.SetFloat("LastPosX", -2.43f);
            PlayerPrefs.SetFloat("LastPosY", 3.93f);

            x = PlayerPrefs.GetFloat("LastPosX");
            y = PlayerPrefs.GetFloat("LastPosY");
            lastPosTransform.position = new Vector2(x, y);
            PlayerPrefs.SetInt("FirstStart", 1);

        }
        else
        {
            lastPosTransform.position = new Vector2(x, y);
            transform.position = lastPosTransform.position;

        }
        destination = lastPosTransform;
	}

	void Update () {
        PlayerPrefs.SetFloat("LastPosX", transform.position.x);
        PlayerPrefs.SetFloat("LastPosY", transform.position.y);
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

        if (Input.GetButtonDown("Select") && isInside && levelLoader)
        {
            Debug.Log(PlayerPrefs.GetFloat("LastPosX"));
            Debug.Log(PlayerPrefs.GetFloat("LastPosY"));
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

    private void OnTriggerStay2D(Collider2D collision)
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
