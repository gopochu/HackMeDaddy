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
    public Text thirdPriceText;
    void Start()
    {
        
    }

    public int Factor(int a, int b)
    {
        double c = Math.Round(Math.Pow(1.3, b));
        return (int)(a * c);
    }
    public void ThirdProduct()
    {
        int basePrice = 40;
        if (counter3 == 0 && points >= basePrice)
        {
            points = points - basePrice;
            counter3++;

            PlayerPrefs.SetInt("counter3", counter3);
            PlayerPrefs.SetInt("points", points);

            isDoubleClick = true;
            PlayerPrefs.SetInt("isDoubleClick", isDoubleClick ? 1 : 0);

            thirdPriceText.text = basePrice.ToString();
        }
        else if (counter3 > 0 && points >= basePrice)
        {
            int price = Factor(basePrice, counter3);
            points = points - price;
            counter3++;

            PlayerPrefs.SetInt("counter3", counter3);
            PlayerPrefs.SetInt("points", points);

            isDoubleClick = true;
            PlayerPrefs.SetInt("isDoubleClick", isDoubleClick ? 1 : 0);

            thirdPriceText.text = Factor(basePrice, counter3).ToString();
        }
    }
    void Update()
    {
        
    }
}
