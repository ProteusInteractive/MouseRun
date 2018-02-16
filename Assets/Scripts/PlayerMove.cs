using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float turnSpeed;
    public float constantSpeed;
    public float MaxSpeedGauge;
    public float fastMultiplier;
    public float slowMultiplier;
    public float gaugeCost;

    float movePerFrame;
    float movePerFrameFast;
    float movePerFrameSlow;
    float vertAxis;
    float speedGauge;

    void Update ()
    {
        CalculateSpeed();
        SpeedUpOrDown();
        Turn();
    }

    private void CalculateSpeed()
    {
        vertAxis = Input.GetAxis("Vertical");
        movePerFrame = constantSpeed * Time.deltaTime;
        movePerFrameFast = Input.GetAxis("Vertical") * movePerFrame * fastMultiplier;
        movePerFrameSlow = Input.GetAxis("Vertical") * movePerFrame * -slowMultiplier;
    }

    private void SpeedUpOrDown()
    {
        if (vertAxis == 0)
        {
            transform.position += transform.right * movePerFrame;
            if (speedGauge < MaxSpeedGauge)
            {
                speedGauge++;
            }
        }
        else
        {
            if (speedGauge > (0.2 * MaxSpeedGauge))
            {
                if (vertAxis > 0)
                {
                    transform.position += transform.right * movePerFrameFast;
                    speedGauge -= gaugeCost;
                }
                if (vertAxis < 0)
                {
                    transform.position += transform.right * movePerFrameSlow;
                    speedGauge -= gaugeCost;
                }
            }
            else
            {
                transform.position += transform.right * movePerFrame;
                if (speedGauge < MaxSpeedGauge)
                {
                    speedGauge++;
                }
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