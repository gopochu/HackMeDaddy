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
    //public Text thirdPriceText;
    public Text fourthPriceText;
    public Text fifthPriceText;
    public int firstPrice;
    public int thirdPrice;
    [SerializeField] bool isDoubleClick;
    public int counter1;
    public int counter3;
    public int counter4;
    public int counter5;
    void Start()
    {
        clc = clickScript.GetComponent<Click>();
        points = PlayerPrefs.GetInt("points");
        totalPoints = PlayerPrefs.GetInt("totalPoints");
        counter1 = PlayerPrefs.GetInt("counter1");
        counter3 = PlayerPrefs.GetInt("counter3");
        counter4 = PlayerPrefs.GetInt("counter4");
        counter5 = PlayerPrefs.GetInt("counter5");
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

    //public void ThirdProduct()
    //{
    //    int basePrice = 40;
    //    if (counter3 == 0 && points >= basePrice)
    //    {
    //        points = points - basePrice;
    //        counter3++;

    //        PlayerPrefs.SetInt("counter3", counter3);
    //        PlayerPrefs.SetInt("points", points);

    //        isDoubleClick = true;
    //        PlayerPrefs.SetInt("isDoubleClick", isDoubleClick ? 1 : 0);

    //        thirdPriceText.text = basePrice.ToString();
    //    }
    //    else if (counter3 > 0 && points >= basePrice)
    //    {
    //        int price = Factor(basePrice, counter3);
    //        points = points - price;
    //        counter3++;

    //        PlayerPrefs.SetInt("counter3", counter3);
    //        PlayerPrefs.SetInt("points", points);

    //        isDoubleClick = true;
    //        PlayerPrefs.SetInt("isDoubleClick", isDoubleClick ? 1 : 0);

    //        thirdPriceText.text = Factor(basePrice, counter3).ToString();
    //    }
    //}

    void Update()
    {
        points = PlayerPrefs.GetInt("points");
        PlayerPrefs.SetInt("points", points);
    }
}
