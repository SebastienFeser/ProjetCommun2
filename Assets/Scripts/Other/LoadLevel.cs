using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    [SerializeField] private string levelName;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource source;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Load()
    {
        source.PlayOneShot(sound);
        Invoke("LoadDelay", 0.2f);
    }

     void LoadDelay()
    {
        SceneManager.LoadScene(levelName);

    }
}
