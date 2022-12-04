using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thirdShopButton : MonoBehaviour
{
    [SerializeField] bool isDoubleClick;
    [SerializeField] public int points;
    public int counter3;
    public int thirdPrice;
    public Text thirdPriceText;
    public bool isFirstBuy;
    public int plusCounter;
    int basePrice = 40;
    void Start()
    {
        isFirstBuy = PlayerPrefs.GetInt("isFirstBuy") == 1 ? true : false;
        thirdPrice = PlayerPrefs.GetInt("thirdPrice");
        if (isFirstBuy)
        {
            thirdPriceText.text = thirdPrice.ToString();
        }
        else
        {
            thirdPriceText.text = basePrice.ToString();
        }
        plusCounter = PlayerPrefs.GetInt("plusCounter");
        points = PlayerPrefs.GetInt("points");
        counter3 = PlayerPrefs.GetInt("counter3");
    }

    public int Factor(int a, int b)
    {
        double c = Math.Round(Math.Pow(1.3, b));
        return (int)(a * c);
    }
    public void ThirdProduct()
    {
        if (counter3 == 0 && points >= basePrice)
        {
            points = points - basePrice;
            PlayerPrefs.SetInt("points", points);

            counter3 = counter3 + 2;
            PlayerPrefs.SetInt("counter3", counter3);

            isFirstBuy = true;
            PlayerPrefs.SetInt("isFirstBuy", isFirstBuy ? 1 : 0);

            plusCounter = plusCounter + 2;
            PlayerPrefs.SetInt("plusCounter", plusCounter);

            isDoubleClick = true;
            PlayerPrefs.SetInt("isDoubleClick", isDoubleClick ? 1 : 0);

            thirdPrice = basePrice;
            thirdPrice = Factor(thirdPrice, counter3);
            PlayerPrefs.SetInt("thirdPrice", thirdPrice);
            thirdPriceText.text = thirdPrice.ToString();
        }
        else if (counter3 > 0 && points >= thirdPrice)
        {
            points = points - thirdPrice;
            PlayerPrefs.SetInt("points", points);

            counter3++;
            PlayerPrefs.SetInt("counter3", counter3);

            plusCounter++;
            PlayerPrefs.SetInt("plusCounter", plusCounter);

            thirdPrice = Factor(thirdPrice, counter3);
            thirdPriceText.text = thirdPrice.ToString();
            PlayerPrefs.SetInt("thirdPrice", thirdPrice);
        }
    }
    void Update()
    {
        points = PlayerPrefs.GetInt("points");
        PlayerPrefs.SetInt("points", points);
        plusCounter = PlayerPrefs.GetInt("plusCounter");
    }
}
