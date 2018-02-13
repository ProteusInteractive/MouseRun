using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float turnSpeed = 5;
    public float constantSpeed = 2f;
    public float moveSpeed = 200;
    public float moveBoost = 0.5f;
    public float speedGauge = 100;
    public float speedValue;
   
	void Update ()
    {
        SpeedUpOrDown();
        Turn();
    }
    
    private void SpeedUpOrDown()
    {
        if (speedGauge > 0 && Input.GetAxis("Vertical") != 0) //if there's available speed gauge and the player hits up/down
        {
            speedGauge -= 3f;
            transform.position += new Vector3(Time.deltaTime * Input.GetAxis("Vertical") * moveBoost, 0f, 0f);
        }
        else
        {
            transform.localPosition += new Vector3(constantSpeed * Time.deltaTime, 0f, 0f);
            if (speedGauge < 100)
            {
                speedGauge++;
            }
        }
    }

    private void Turn()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0f, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0f);
        }
    }
}
