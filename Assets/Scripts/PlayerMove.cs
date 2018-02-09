using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float turnSpeed;
    public float moveSpeed;
    public float speedGauge;

    public Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	    
	void Update ()
    {

        checkTurn();

        if (Input.GetAxis("Vertical") != 0)
        {
            if (speedGauge >= 0)
            {
                speedGauge -= 1f;
                //increase/decrease velocity by multiplying getaxis.vertical by time.deltatime
            } 
            
        }
        else
        {
            //set velocity to the standard bullet speed
        }

    }

    private void checkTurn()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0f, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0f);
        }
    }
}
