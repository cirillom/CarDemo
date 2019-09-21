﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CarController))]
public class CarHUD : MonoBehaviour
{
    CarController carControllerScript;
    private float minNeedleAng = 90f, maxNeedleAng = -90f;
    public Image engineRPMNeedle;
    public Text engineRPMText, actualGearText, speedText;

    void Start()
    {
        carControllerScript = GetComponent<CarController>();
    }

    void Update()
    {
        ChangeTexts();
        ChangeRPMNeedle();
    }

    public void ChangeTexts()
    {
        engineRPMText.text = Helper.Round(CarController.engineRPM, 0).ToString();
        actualGearText.text = (carControllerScript.gear.actual - 1).ToString();
        speedText.text = Helper.Round(CarController.carSpeed * 3.6f, 2) + "km/h";
    }

    public void ChangeRPMNeedle()
    {
        float angRPM = Mathf.Lerp(minNeedleAng, maxNeedleAng, Mathf.Abs(CarController.engineRPM) / carControllerScript.engineRPMLimit);
        engineRPMNeedle.transform.eulerAngles = new Vector3(0, 0, angRPM);
    }
}
