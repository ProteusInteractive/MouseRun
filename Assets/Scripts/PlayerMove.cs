﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float turnSpeed;
    public float constantSpeed;
    public float MaxSpeedGauge;
    public float fastMultiplier;
    public float slowMultiplier;
    public float gaugeCost;

    public Text gaugeLabel;
    public Image gaugeBar;

    float movePerFrame;
    float movePerFrameFast;
    float movePerFrameSlow;
    float vertAxis;
    float speedGauge;

    private void Start()
    {
        speedGauge = MaxSpeedGauge;
    }

    void Update ()
    {
        CalculateSpeed();
        SpeedUpOrDown();
        Turn();
        GaugeUI();
		IsGameOver ();
    }

    private void GaugeUI()
    {
        gaugeLabel.text = "Gauge";
        gaugeBar.rectTransform.sizeDelta = new Vector2 (((speedGauge / MaxSpeedGauge) * 100), 15.8f);
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

	private void IsGameOver()
	{
		RaycastHit hitInfo;
		Vector3 fwdDir = transform.right - transform.up;
		if (Physics.Raycast(transform.position, fwdDir, out hitInfo, 5))
		{
			String RayTile = hitInfo.transform.gameObject.name;
			if (RayTile == "Finish")
			{
				//Dummy code to show game over
				SceneManager.LoadScene("Sandbox");
			}
		}
	}
}