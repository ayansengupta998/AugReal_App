﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderNumber : MonoBehaviour
{
    Text valueText;

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    public void textUpdate (float value)
    {
        valueText.text = Mathf.RoundToInt(value * 100) + "in";
    }
}
