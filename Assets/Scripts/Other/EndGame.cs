using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private GameObject text1, text2, text3, text4, text5;
    [SerializeField] private float time;
    [SerializeField] private float fadespeed;
    [SerializeField] private string Map;

	// Use this for initialization
	void Start () {

        StartCoroutine("fade");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator fade()
    {
        for (float i = 1.0f; i > 0.1f; i -= 0.01f)
        {
            background.color = new Color(i, i, i);
            yield return new WaitForSeconds(fadespeed);
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("End");
    }

    IEnumerator End()
    {
        text1.SetActive(true);
        yield return new WaitForSeconds(time);
        text2.SetActive(true);
        yield return new WaitForSeconds(time);
        text3.SetActive(true);
        yield return new WaitForSeconds(time);
        text4.SetActive(true);
        yield return new WaitForSeconds(time);
        text5.SetActive(true);
        yield return new WaitForSeconds(time);
        for (float i = 0.1f; i > 0f; i -= 0.01f)
        {
            background.color = new Color(i, i, i);
            yield return new WaitForSeconds(fadespeed*2);
        }
        SceneManager.LoadScene(Map);
    }
}
