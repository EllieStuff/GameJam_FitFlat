﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    Button man_button;
    Button girl_button;

    // Start is called before the first frame update
    void Start()
    {
        man_button.onClick.AddListener(() => SelectGenere());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectGenere()
    {

    }
}