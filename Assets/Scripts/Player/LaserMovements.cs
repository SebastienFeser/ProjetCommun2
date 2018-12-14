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

    private EnemyController.deathType type;
    public EnemyController.deathType Type
    {
        set { type = value; }
    }

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
    float coolDownBarSize = 100f;

    [SerializeField] Image normalCoolDownBar;
    [SerializeField] Image electricCoolDownBar;
    [SerializeField] Image gazCoolDownBar;
    [SerializeField] Image fireCoolDownBar;
    [SerializeField] Image iceCoolDownBar;

    [SerializeField] float normalCoolDownTime;
    [SerializeField] float electricCoolDownTime;
    [SerializeField] float gazCoolDownTime;
    [SerializeField] float fireCoolDownTime;
    [SerializeField] float iceCoolDownTime;

    bool canShootNormal = true;
    bool canShootElectric = true;
    bool canShootGaz = true;
    bool canShootFire = true;
    bool canShootIce = true;
    #endregion

    void Start () {
        type = EnemyController.deathType.normal;
        StartCoroutine("moveLeft");
        transform.eulerAngles = new Vector3(0, 0, minimumAngle);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {

            switch (type)
            {
                case EnemyController.deathType.normal:
                    if (canShootNormal)
                    {
                        frisbeeVectorSpeed = SpeedCalculator();
                        GameObject frisbee = Instantiate(frisbeeGameObject, gameObject.transform.position, Quaternion.identity);
                        frisbee.GetComponent<Frisbee>().TypeFrisbee = type;
                        frisbee.GetComponent<Frisbee>().FrisbeeSpeed = frisbeeVectorSpeed;

                        StartCoroutine("normalFrisbeeCoolDown");
                        canShootNormal = false;
                    }
                    break;
                case EnemyController.deathType.electric:
                    if (canShootElectric)
                    {
                        frisbeeVectorSpeed = SpeedCalculator();
                        GameObject frisbee = Instantiate(frisbeeGameObject, gameObject.transform.position, Quaternion.identity);
                        frisbee.GetComponent<Frisbee>().TypeFrisbee = type;
                        frisbee.GetComponent<Frisbee>().FrisbeeSpeed = frisbeeVectorSpeed;
                        Debug.Log("test");

                        StartCoroutine("electricFrisbeeCoolDown");
                        canShootElectric = false;
                    }
                    break;
                case EnemyController.deathType.gaz:
                    if (canShootGaz)
                    {
                        frisbeeVectorSpeed = SpeedCalculator();
                        GameObject frisbee = Instantiate(frisbeeGameObject, gameObject.transform.position, Quaternion.identity);
                        frisbee.GetComponent<Frisbee>().TypeFrisbee = type;
                        frisbee.GetComponent<Frisbee>().FrisbeeSpeed = frisbeeVectorSpeed;

                        StartCoroutine("gazFrisbeeCoolDown");
                        canShootGaz = false;
                    }
                    break;
                case EnemyController.deathType.ice:
                    if (canShootIce)
                    {
                        frisbeeVectorSpeed = SpeedCalculator();
                        GameObject frisbee = Instantiate(frisbeeGameObject, gameObject.transform.position, Quaternion.identity);
                        frisbee.GetComponent<Frisbee>().TypeFrisbee = type;
                        frisbee.GetComponent<Frisbee>().FrisbeeSpeed = frisbeeVectorSpeed;

                        StartCoroutine("iceFrisbeeCoolDown");
                        canShootIce = false;
                    }
                    break;
                case EnemyController.deathType.fire:
                    if (canShootFire)
                    {
                        frisbeeVectorSpeed = SpeedCalculator();
                        GameObject frisbee = Instantiate(frisbeeGameObject, gameObject.transform.position, Quaternion.identity);
                        frisbee.GetComponent<Frisbee>().TypeFrisbee = type;
                        frisbee.GetComponent<Frisbee>().FrisbeeSpeed = frisbeeVectorSpeed;

                        StartCoroutine("fireFrisbeeCoolDown");
                        canShootFire = false;
                    }
                    break;
            }
            
        }
	}

    IEnumerator moveLeft()
    {
        for(float i = minimumAngle; i < maximumAngle; i+=2)
        {
            transform.Rotate(0, 0, 2);
            yield return new WaitForSeconds(pointerSpeed/100);
        }

        StartCoroutine("moveRight");
        
    }

    IEnumerator moveRight()
    {
        for (float i = maximumAngle; i > minimumAngle; i-=2)
        {
            transform.Rotate(0, 0, -2);
            yield return new WaitForSeconds(pointerSpeed/100);
        }

        StartCoroutine("moveLeft");
    }

    IEnumerator normalFrisbeeCoolDown()
    {
        for (float i = 0; i < coolDownBarSize; i++)
        {
            normalCoolDownBar.fillAmount = i / coolDownBarSize;
            yield return new WaitForSeconds(normalCoolDownTime/coolDownBarSize);
        }
        normalCoolDownBar.fillAmount = 1;
        canShootNormal = true;
    }

    IEnumerable electricFrisbeeCoolDown()
    {
        for (float i = 0; i < coolDownBarSize; i++)
        {
            electricCoolDownBar.fillAmount = i / coolDownBarSize;
            yield return new WaitForSeconds(electricCoolDownTime / coolDownBarSize);
        }
        electricCoolDownBar.fillAmount = 1;
        canShootElectric = true;
    }

    IEnumerable gazFrisbeeCoolDown()
    {
        for (float i = 0; i < coolDownBarSize; i++)
        {
            gazCoolDownBar.fillAmount = i / coolDownBarSize;
            yield return new WaitForSeconds(gazCoolDownTime / coolDownBarSize);
        }
        gazCoolDownBar.fillAmount = 1;
        canShootGaz = true;
    }

    IEnumerable fireFrisbeeCoolDown()
    {
        for (float i = 0; i < coolDownBarSize; i++)
        {
            fireCoolDownBar.fillAmount = i / coolDownBarSize;
            yield return new WaitForSeconds(fireCoolDownTime / coolDownBarSize);
        }
        fireCoolDownBar.fillAmount = 1;
        canShootFire = true;
    }

    IEnumerable iceFrisbeeCoolDown()
    {
        for (float i = 0; i < coolDownBarSize; i++)
        {
            iceCoolDownBar.fillAmount = i / coolDownBarSize;
            yield return new WaitForSeconds(iceCoolDownTime / coolDownBarSize);
        }
        iceCoolDownBar.fillAmount = 1;
        canShootIce = true;
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
