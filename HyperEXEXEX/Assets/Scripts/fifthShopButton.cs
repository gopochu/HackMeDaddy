using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fifthShopButton : MonoBehaviour
{
    [SerializeField] public int points;
    public int counter5;
    public int fifthPrice;
    public Text fifthPriceText;
    public bool isBuy;
    public int factorCounter = 1;
    int basePrice = 25;
    void Start()
    {
        isBuy = PlayerPrefs.GetInt("isBuy") == 1 ? true : false;
        fifthPrice = PlayerPrefs.GetInt("fifthPrice");
        if (isBuy)
        {
            fifthPriceText.text = fifthPrice.ToString();
        }
        else
        {
            fifthPriceText.text = basePrice.ToString();
            factorCounter = 1;
            PlayerPrefs.SetInt("factorCounter", factorCounter);

        }
        factorCounter = PlayerPrefs.GetInt("factorCounter");
        points = PlayerPrefs.GetInt("points");
        counter5 = PlayerPrefs.GetInt("counter5");
    }
    public int Factor(int a, int b)
    {
        double c = Math.Round(Math.Pow(1.3, b));
        return (int)(a * c);
    }
    public void fifthProduct()
    {
        if (counter5 == 0 && points >= basePrice)
        {
            points = points - basePrice;
            PlayerPrefs.SetInt("points", points);

            counter5 = counter5 + 2;
            PlayerPrefs.SetInt("counter5", counter5);

            isBuy = true;
            PlayerPrefs.SetInt("isBuy", isBuy ? 1 : 0);

            factorCounter = factorCounter + 1;
            PlayerPrefs.SetInt("factorCounter", factorCounter);

            fifthPrice = basePrice;
            fifthPrice = Factor(fifthPrice, counter5);
            PlayerPrefs.SetInt("fifthPrice", fifthPrice);
            fifthPriceText.text = fifthPrice.ToString();
        }
        else if (counter5 > 0 && points >= fifthPrice)
        {
            points = points - fifthPrice;
            PlayerPrefs.SetInt("points", points);

            counter5++;
            PlayerPrefs.SetInt("counter5", counter5);

            factorCounter++;
            PlayerPrefs.SetInt("plusCounter", factorCounter);

            fifthPrice = Factor(fifthPrice, counter5);
            fifthPriceText.text = fifthPrice.ToString();
            PlayerPrefs.SetInt("fifthPrice", fifthPrice);
        }
    }
    void Update()
    {
        points = PlayerPrefs.GetInt("points");
        PlayerPrefs.SetInt("points", points);
        factorCounter = PlayerPrefs.GetInt("factorCounter");
    }
}
