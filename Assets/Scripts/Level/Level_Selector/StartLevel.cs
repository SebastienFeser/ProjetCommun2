using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {
    [SerializeField] private string levelToLoad;

	public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
