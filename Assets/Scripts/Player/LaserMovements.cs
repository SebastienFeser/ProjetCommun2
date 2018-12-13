using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovements : MonoBehaviour {

    [SerializeField] float minimumAngle = -45;
    [SerializeField] float maximumAngle = 45;
    [SerializeField] float frisbeeSpeed;
    [SerializeField] GameObject frisbeeGameObject;
    [SerializeField] float pointerSpeed = 0.01f;

    bool goLeft = true;
    bool calledOnceInFunction = true;

    Vector2 frisbeeVectorSpeed;

    public Vector2 FrisbeeSpeed
    {
        get
        {
            return frisbeeVectorSpeed;
        }
    }

    #region Used for Speed Calculator
    float frisbeeXVelocity;
    float frisbeeYVelocity;
    float pointerAngle;
    #endregion
    


    void Start () {
        StartCoroutine("moveLeft");
        transform.eulerAngles = new Vector3(0, 0, minimumAngle);
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            frisbeeVectorSpeed = SpeedCalculator();
            GameObject frisbee = Instantiate(frisbeeGameObject, gameObject.transform.position, Quaternion.identity);
            frisbee.GetComponent<Frisbee>().FrisbeeSpeed = frisbeeVectorSpeed;
        }
	}

    IEnumerator moveLeft()
    {
        for(float i = minimumAngle; i < maximumAngle; i++)
        {
            transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(pointerSpeed);
        }

        StartCoroutine("moveRight");
        
    }

    IEnumerator moveRight()
    {
        for (float i = maximumAngle; i > minimumAngle; i--)
        {
            transform.Rotate(0, 0, -1);
            yield return new WaitForSeconds(pointerSpeed);
        }

        StartCoroutine("moveLeft");
    }

    Vector2 SpeedCalculator()
    {
        Vector2 speed;
        frisbeeXVelocity = Mathf.Sin(transform.rotation.z *2) * -frisbeeSpeed;
        frisbeeYVelocity = Mathf.Cos(transform.rotation.z *2) * frisbeeSpeed;
        speed = new Vector2(frisbeeXVelocity, frisbeeYVelocity);
        return speed;
    }
}
