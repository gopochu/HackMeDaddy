using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Click : MonoBehaviour
{
    [SerializeField] public int points;
    public Text pointsText;
    public int totalPoints;
    [SerializeField] public bool isDoubleClick;

    void Start()
    {
        points = PlayerPrefs.GetInt("points");
        totalPoints = PlayerPrefs.GetInt("totalPoints");
    }

    public void UpdatePoints()
    {
        points = PlayerPrefs.GetInt("points");
    }

    public void ButtonClick()
    {
        if (isDoubleClick)
        {
            points = points + 2;
            totalPoints++;
            PlayerPrefs.SetInt("points", points);
            PlayerPrefs.SetInt("totalPoints", totalPoints);
        }
        else
        {
            points++;
            totalPoints++;
            PlayerPrefs.SetInt("points", points);
            PlayerPrefs.SetInt("totalPoints", totalPoints);
        }
    }
    //a to z + space + enter + backspace + 0 to 9
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ButtonClick();
        }
        //points = PlayerPrefs.GetInt("points");
        pointsText.text = points.ToString();
        isDoubleClick = PlayerPrefs.GetInt("isDoubleClick") == 1 ? true : false;
    }
}
