using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    [SerializeField] public int counter;
    [SerializeField] public int points;
    [SerializeField] bool isPassivePlus;
    [SerializeField] public int passivePlus;
    [SerializeField] public int totalPoints;
    GameObject clickScript;
    [SerializeField] private Click clc;
    public Text firstPriceText;
    public Text secondPriceText;
    public Text thirdPriceText;
    public Text fourthPriceText;
    public Text fifthPriceText;
    public int firstPrice;
    public int secondPrice;
    public int thirdPrice;
    public int fourthPrice;
    public int fifthPrice;
    [SerializeField] bool isDoubleClick;
    public int counter1;
    public int counter2;
    public int counter3;
    public int counter4;
    public int counter5;
    void Start()
    {
        passivePlus = PlayerPrefs.GetInt("passivePlus");
        StartCoroutine(PassiveFarm());
        //isPassivePlus = PlayerPrefs.GetInt("isPassivePlus") == 1 ? true : false;
        clc = clickScript.GetComponent<Click>();
        passivePlus = PlayerPrefs.GetInt("passivePlus");
        points = PlayerPrefs.GetInt("points");
        totalPoints = PlayerPrefs.GetInt("totalPoints");
        counter1 = PlayerPrefs.GetInt("counter1");
        counter2 = PlayerPrefs.GetInt("counter2");
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

    public void SecondProduct()
    {
        int basePrice = 20;
        if (counter2 == 0 && points >= basePrice)
        {
            points = points - basePrice;
            passivePlus++;
            PlayerPrefs.SetInt("passivePlus", passivePlus);

            counter2++;

            int price = Factor(basePrice, counter2);
            secondPrice = price;

            PlayerPrefs.SetInt("counter2", counter2);
            PlayerPrefs.SetInt("points", points);
            
            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
        else if (counter2 > 0 && points >= basePrice)
        {
            int price = secondPrice;
            points = points - price;
            price = Factor(basePrice, counter2);
            secondPrice = price;
            
            passivePlus++;
            PlayerPrefs.SetInt("passivePlus", passivePlus);

            counter2++;

            PlayerPrefs.SetInt("counter2", counter2);
            PlayerPrefs.SetInt("points", points);
            secondPriceText.text = price.ToString();
            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
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
            thirdPriceText.text = basePrice.ToString();
        }
    }
    public void FourthProduct()
    {
        int basePrice = 20;
        if (counter3 == 0 && points >= basePrice)
        {
            points = points - basePrice;
            passivePlus = passivePlus * 2;
            PlayerPrefs.SetInt("passivePlus", passivePlus);
            counter3++;
            PlayerPrefs.SetInt("counter3", counter3);
            PlayerPrefs.SetInt("points", points);
            fourthPriceText.text = basePrice.ToString();
            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
        else if (counter3 > 0 && points >=basePrice)
        {
            int price = Factor(basePrice, counter3);
            points = points - price;
            passivePlus++;
            PlayerPrefs.SetInt("passivePlus", passivePlus);
            counter3++;
            PlayerPrefs.SetInt("counter3", counter3);
            PlayerPrefs.SetInt("points", points);
            secondPriceText.text = basePrice.ToString();
            StartCoroutine(PassiveFarm());
            clc.UpdatePoints();
        }
    }
    public void FifthProduct()
    {

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
    }
}
