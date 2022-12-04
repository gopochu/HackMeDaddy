using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class secondShopButton : MonoBehaviour
{
    public int secondPrice;
    public int counter2 = 20;
    public Text secondPriceText;
    [SerializeField] public int points;
    [SerializeField] bool isPassivePlus;
    [SerializeField] public int passivePlus;
    [SerializeField] private Click clc;
    GameObject clickScript;
    void Start()
    {
        isPassivePlus = PlayerPrefs.GetInt("isPassivePlus") == 1 ? true : false;
        passivePlus = PlayerPrefs.GetInt("passivePlus");
        secondPrice = PlayerPrefs.GetInt("secondPrice");
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
    public void SecondProduct()
    {
        if (counter2 == 0 && points >= 20)
        {
            secondPrice = 20;
            PlayerPrefs.SetInt("secondPrice", secondPrice);

            points = points - 20;
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

    // Update is called once per frame
    void Update()
    {
        points = PlayerPrefs.GetInt("points");
        PlayerPrefs.SetInt("points", points);
        secondPriceText.text = secondPrice.ToString();
        PlayerPrefs.GetInt("secondPrice");
    }
}
