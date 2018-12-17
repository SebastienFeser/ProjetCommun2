using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResolution : MonoBehaviour {
    [SerializeField] private Vector2 ratio;
    [SerializeField] private int HRes;
    [SerializeField] private Vector2 finalResolution;
	// Use this for initialization
	void Start () {
        finalResolution = new Vector2(Mathf.RoundToInt(((HRes * ratio.x) / ratio.y)), HRes);
        Screen.SetResolution((int)finalResolution.x, (int)finalResolution.y, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnValidate()
    {
        finalResolution = new Vector2(Mathf.RoundToInt(((HRes * ratio.x) / ratio.y)), HRes);
    }
}
