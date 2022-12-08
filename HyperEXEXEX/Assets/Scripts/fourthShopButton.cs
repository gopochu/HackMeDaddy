using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fourthShopButton : MonoBehaviour
{
    [SerializeField] public int points;
    public int counter4;
    public int fourthPrice;
    public Text fourthPriceText;
    public bool isFirst;
    int basePrice = 30;
    public int passiveFactor = 1;
    public int passivePlus;
    GameObject clickScript;
    [SerializeField] private Click clc;
    void Start()
    {
        isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        fourthPrice = PlayerPrefs.GetInt("fourthPrice");
        counter4 = PlayerPrefs.GetInt("counter4");
        passiveFactor = PlayerPrefs.GetInt("passiveFactor");
        if (isFirst)
        {
            StartCoroutine(PassiveFarm());
            fourthPriceText.text = fourthPrice.ToString();
        }
        else
        {
            fourthPriceText.text = basePrice.ToString();
        }
        points = PlayerPrefs.GetInt("points");
        
        
        clc = clickScript.GetComponent<Click>();
    }
    public int Factor(int a, int b)
    {
        double c = Math.Round(Math.Pow(1.3, b));
        return (int)(a * c);
    }

    public void fourthProduct()
    {
        if (counter4 == 0 && points >= basePrice)
        {
            points = points - basePrice;
            PlayerPrefs.SetInt("points", points);

            passiveFactor = passiveFactor + 2;
            PlayerPrefs.SetInt("passiveFactor", passiveFactor);

            counter4 = counter4 + 2;
            PlayerPrefs.SetInt("counter4", counter4);

            isFirst = true;
            PlayerPrefs.SetInt("isFirst", isFirst ? 1 : 0);

            fourthPrice = basePrice;
            fourthPrice = Factor(fourthPrice, counter4);
            PlayerPrefs.SetInt("fourthPrice", fourthPrice);
            fourthPriceText.text = fourthPrice.ToString();

            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
        else if (counter4 > 0 && points >= fourthPrice)
        {
            points = points - fourthPrice;
            PlayerPrefs.SetInt("points", points);

            passiveFactor++;
            PlayerPrefs.SetInt("passivePlus", passiveFactor);

            counter4++;
            PlayerPrefs.SetInt("counter4", counter4);

            fourthPrice = Factor(fourthPrice, counter4);
            fourthPriceText.text = fourthPrice.ToString();
            PlayerPrefs.SetInt("fourthPrice", fourthPrice);

            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
    }
    IEnumerator PassiveFarm()
    {
        passivePlus = PlayerPrefs.GetInt("passivePlus");
        yield return new WaitForSeconds(1);
        points = points + (passiveFactor * passivePlus);
        Debug.Log(points);
        PlayerPrefs.SetInt("points", points);
        clc.UpdatePoints();
        StartCoroutine(PassiveFarm());
    }
    void Update()
    {
        points = PlayerPrefs.GetInt("points");
        PlayerPrefs.SetInt("points", points);
        fourthPriceText.text = fourthPrice.ToString();
        PlayerPrefs.GetInt("fourthPrice");
    }
}
