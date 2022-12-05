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
    public int plusCounter;

    void Start()
    {
        points = PlayerPrefs.GetInt("points");
        totalPoints = PlayerPrefs.GetInt("totalPoints");
        isDoubleClick = PlayerPrefs.GetInt("isDouleClick") == 1 ? true : false;
    }

    public void UpdatePoints()
    {
        points = PlayerPrefs.GetInt("points");
    }

    public void ButtonClick()
    {
        if (isDoubleClick)
        {
            points = points + plusCounter;
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
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ButtonClick();
        }
        pointsText.text = points.ToString();
        isDoubleClick = PlayerPrefs.GetInt("isDoubleClick") == 1 ? true : false;
        plusCounter = PlayerPrefs.GetInt("plusCounter");
    }
}
