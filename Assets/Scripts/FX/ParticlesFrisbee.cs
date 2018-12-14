using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFrisbee : MonoBehaviour {
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Detatch()
    {
        particleSystem.emissionRate = 0;
        transform.parent = null;
        Destroy(gameObject, 2);
    }
}
