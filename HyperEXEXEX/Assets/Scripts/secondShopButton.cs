using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class secondShopButton : MonoBehaviour
{
    public int secondPrice;
    public int counter2;
    public Text secondPriceText;
    [SerializeField] public int points;
    [SerializeField] bool isPassivePlus;
    [SerializeField] public int passivePlus;
    [SerializeField] private Click clc;
    GameObject clickScript;
    public bool firstBuy;
    int basePrice = 20;
    void Start()
    {
        firstBuy = PlayerPrefs.GetInt("firstBuy") == 1 ? true : false;
        secondPrice = PlayerPrefs.GetInt("secondPrice");
        if (firstBuy)
        {
            secondPriceText.text = secondPrice.ToString();
        }
        else
        {
            secondPriceText.text = basePrice.ToString();
        }
        isPassivePlus = PlayerPrefs.GetInt("isPassivePlus") == 1 ? true : false;
        passivePlus = PlayerPrefs.GetInt("passivePlus");
        counter2 = PlayerPrefs.GetInt("counter2");
        points = PlayerPrefs.GetInt("points");
        StartCoroutine(PassiveFarm());
        clc = clickScript.GetComponent<Click>();
    }
    public int Factor(int a, int b)
    {
        double c = Math.Round(Math.Pow(1.3, b));
        return (int)(a * c);
    }
    public void secondProduct()
    {
        if (counter2 == 0 && points >= basePrice)
        {
            points = points - basePrice;
            PlayerPrefs.SetInt("points", points);

            passivePlus++;
            PlayerPrefs.SetInt("passivePlus", passivePlus);

            counter2 = counter2 + 2;
            PlayerPrefs.SetInt("counter2", counter2);

            firstBuy = true;
            PlayerPrefs.SetInt("firstBuy", firstBuy ? 1 : 0);

            secondPrice = basePrice;
            secondPrice = Factor(secondPrice, counter2);
            PlayerPrefs.SetInt("secondPrice", secondPrice);
            secondPriceText.text = secondPrice.ToString();

            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
        else if (counter2 > 0 && points >= secondPrice)
        {
            points = points - secondPrice;
            PlayerPrefs.SetInt("points", points);

            passivePlus++;
            PlayerPrefs.SetInt("passivePlus", passivePlus);

            counter2++;
            PlayerPrefs.SetInt("counter2", counter2);

            secondPrice = Factor(secondPrice, counter2);
            secondPriceText.text = secondPrice.ToString();
            PlayerPrefs.SetInt("secondPrice", secondPrice);

            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
    }
    IEnumerator PassiveFarm()
    {
        yield return new WaitForSeconds(1);
        points = points + passivePlus;
        Debug.Log(points);
        PlayerPrefs.SetInt("points", points);
        clc.UpdatePoints();
        StartCoroutine(PassiveFarm());
    }

    void Update()
    {
        points = PlayerPrefs.GetInt("points");
        PlayerPrefs.SetInt("points", points);
        secondPriceText.text = secondPrice.ToString();
        PlayerPrefs.GetInt("secondPrice");
    }
}
