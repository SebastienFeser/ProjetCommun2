using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {
    [SerializeField] private string levelToLoad;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource source;

	public void LoadLevel()
    {
        source.PlayOneShot(sound);
        Invoke("LoadDelay", 0.2f);
    }

    void LoadDelay()
    {
        SceneManager.LoadScene(levelToLoad);

    }
}
