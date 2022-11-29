using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Advert : MonoBehaviour
{
    public int points;
    [SerializeField] Button advertButton;
    [SerializeField] bool isButton;
    [SerializeField] Image leftBottom;
    [SerializeField] Image rightTopper;
    void Start()
    {
        isButton = PlayerPrefs.GetInt("isButton") == 1 ? true : false;
        points = PlayerPrefs.GetInt("totalPoints");

    }
    private void CheckPoints()
    {
        if (points >= 10 && !isButton)
        {
            advertButton.interactable = true;
        }
        else
        {
            advertButton.interactable = false;
        }
    }
    public void GetAdvert()
    {
        isButton = true;
        PlayerPrefs.SetInt("isButton", isButton ? 1 : 0);
    }
    public void CheckImage()
    {
        if (!isButton)
        {
            leftBottom.gameObject.SetActive(true);
            rightTopper.gameObject.SetActive(false);
        }
        else
        {
            leftBottom.gameObject.SetActive(false);
            rightTopper.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isButton);
        CheckPoints();
    }
}
