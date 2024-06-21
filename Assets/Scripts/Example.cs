using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    [SerializeField] private Text textDesc;
    
    private void Awake()
    {
        if (SimulatorChecker.IsRunningOnSimulator())
        {
            textDesc.text = "是";
        }
        else
        {
            textDesc.text = "否";
        }
    }
}
