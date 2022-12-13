using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class giftsScript : MonoBehaviour
{
    public int counter2;
    public GameObject gif1;
    public GameObject gif2;
    public GameObject gif3;
    public GameObject gif4;
    public GameObject gif5;
    public GameObject gif6;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter2 = PlayerPrefs.GetInt("counter2");
        if (counter2 >= 2)
        {
            gif1.gameObject.SetActive(true);
        };
        if(counter2 >= 3)
        {
            gif2.gameObject.SetActive(true);
        }
        if(counter2 >= 4)
        {
            gif3.gameObject.SetActive(true);
        };
        if(counter2 >= 5)
        {
            gif4.gameObject.SetActive(true);
        };
        if(counter2 >= 6)
        {
            gif5.gameObject.SetActive(true);
        };
        if(counter2 >= 7)
        {
            gif6.gameObject.SetActive(true);
        };
    }
}
