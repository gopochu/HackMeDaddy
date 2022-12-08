using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    [SerializeField] public int counter;
    [SerializeField] public int points;
    [SerializeField] public int totalPoints;
    GameObject clickScript;
    [SerializeField] private Click clc;
    public Text firstPriceText;
    public int firstPrice;
    public int thirdPrice;
    public int counter1;
    void Start()
    {
        clc = clickScript.GetComponent<Click>();
        points = PlayerPrefs.GetInt("points");
        totalPoints = PlayerPrefs.GetInt("totalPoints");
        counter1 = PlayerPrefs.GetInt("counter1");
    }
    public int Factor(int a, int b)
    {
        double c = Math.Round(Math.Pow(1.3, b));
        return (int)(a * c);
    }
    public void FirstProduct()
    {
        firstPrice = 5;
        if (counter == 0 && points >= firstPrice)
        {
            points = points - firstPrice + 10;
            PlayerPrefs.SetInt("points", points);
            counter++;
            PlayerPrefs.SetInt("counter", counter);
            clc.UpdatePoints();
        }
        else if (counter > 0 && points >= firstPrice)
        {
            int price = Factor(firstPrice, counter);
            points = points - price + 10;
            PlayerPrefs.SetInt("points", points);
            counter++;
            PlayerPrefs.SetInt("counter", counter);
            clc.UpdatePoints();
        }
    }

    public void FirstProductNum2()
    {
        firstPrice = 100;
        System.Random x = new System.Random();
        int randomPoints;
        if (points >= firstPrice)
        {
            randomPoints = x.Next(0, 200);
            points = points - firstPrice + randomPoints;
            PlayerPrefs.SetInt("points", points);
            counter++;
            PlayerPrefs.SetInt("counter1", counter1);
            clc.UpdatePoints();
            firstPriceText.text = firstPrice.ToString();
        }
    }

    void Update()
    {
        points = PlayerPrefs.GetInt("points");
        PlayerPrefs.SetInt("points", points);
    }
}
