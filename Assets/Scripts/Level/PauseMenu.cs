using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioMixerSnapshot normal, paused;

    private bool isPaused;
	void Start () {
		
	}
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.P)){
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
        }

        if (isPaused)
        {
            paused.TransitionTo(0.01f);
            Time.timeScale = 0;
        }
        else
        {
            normal.TransitionTo(0.01f);
            Time.timeScale = 1;
        }
	}

    public void Continue()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
    }
}
