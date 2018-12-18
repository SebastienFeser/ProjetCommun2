using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour {
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle()
    {
        source.PlayOneShot(clip);
        objectToActivate.SetActive(!objectToActivate.active);
    }
}
