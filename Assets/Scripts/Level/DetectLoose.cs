using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLoose : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private float speed;
    [SerializeField] private Color color;
    [SerializeField] private Transform posLow;
    [SerializeField] private GameObject shootRoof;

    private SpriteRenderer spr;
    private int distanceUntilLoose;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        StartCoroutine("Blink");
    }

    private void Update()
    {
        distanceUntilLoose = Mathf.RoundToInt(transform.position.y - posLow.position.y);
        switch (distanceUntilLoose)
        {
            case -7:
                speed = 5;
                shootRoof.SetActive(true);
                break;
            case -5:
                speed = 10;

                break;
            case -3:
                speed = 20;
                break;
            case -1:
                speed = 40;
                break;
        }
        spr.color = color;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameManager.AsLost();
        }
    }

    IEnumerator Blink()
    {

        while (true) {
            for (float i = 0; i < 0.5f; i += 0.01f)
            {
                color = new Color(1, 0, 0, i);
                yield return new WaitForSeconds(1/(speed*5));
            }

            for (float i = 0.5f; i > 0; i -= 0.01f)
            {
                color = new Color(1, 0, 0, i);
                yield return new WaitForSeconds(1/(speed*5));
            }
        }
        
       
    }
}
