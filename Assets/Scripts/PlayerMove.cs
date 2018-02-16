using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float turnSpeed = 8f;
    public float constantSpeed = 50f;
    public float moveBoost = 0.5f;
    public float speedGauge = 100f;
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
            transform.position += transform.right * Input.GetAxis("Vertical") * constantSpeed * Time.deltaTime * moveBoost;
        }
        else
        {
            transform.position += transform.right * Input.GetAxis("Vertical") * constantSpeed * Time.deltaTime;
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