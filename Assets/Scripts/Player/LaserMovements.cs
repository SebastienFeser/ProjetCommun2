using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserMovements : MonoBehaviour {

    [SerializeField] float minimumAngle = -45;
    [SerializeField] float maximumAngle = 45;
    [SerializeField] float frisbeeSpeed;
    [SerializeField] GameObject frisbeeGameObject;
    [SerializeField] float pointerSpeed;

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

    #region Used for Cooldown
    [SerializeField] Image coolDownBar;
    [SerializeField] float coolDownTime;
    float coolDownBarSize = 100f;
    bool canShoot = true;
    #endregion

    void Start () {
        StartCoroutine("moveLeft");
        transform.eulerAngles = new Vector3(0, 0, minimumAngle);
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            frisbeeVectorSpeed = SpeedCalculator();
            GameObject frisbee = Instantiate(frisbeeGameObject, gameObject.transform.position, Quaternion.identity);
            frisbee.GetComponent<Frisbee>().FrisbeeSpeed = frisbeeVectorSpeed;
            StartCoroutine("frisbeeCoolDown");
            canShoot = false;
        }
	}

    IEnumerator moveLeft()
    {
        for(float i = minimumAngle; i < maximumAngle; i+=2)
        {
            transform.Rotate(0, 0, 2);
            yield return new WaitForSeconds(pointerSpeed);
        }

        StartCoroutine("moveRight");
        
    }

    IEnumerator moveRight()
    {
        for (float i = maximumAngle; i > minimumAngle; i-=2)
        {
            transform.Rotate(0, 0, -2);
            yield return new WaitForSeconds(pointerSpeed);
        }

        StartCoroutine("moveLeft");
    }

    IEnumerator frisbeeCoolDown()
    {
        for (float i = 0; i < coolDownBarSize; i++)
        {
            coolDownBar.fillAmount = i / coolDownBarSize;
            yield return new WaitForSeconds(coolDownTime/coolDownBarSize);
        }
        coolDownBar.fillAmount = 1;
        canShoot = true;
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
