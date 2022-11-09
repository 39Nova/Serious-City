using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{

    public Slider slider;
    public static float MoneyLvl;
    public float MoneyBarLvl;
    Text text;

    void Start()
    {
        text = GetComponentInChildren<Text>();
    }
    public void SetMoney(float MoneyLvl)
    {

        MoneyBarLvl = MoneyBarLvl + MoneyLvl;
        Debug.Log(text);
        ////slider.value = MoneyBarLvl;
    }
    void Update()
    {
        text.text = "Money: " + MoneyBarLvl;
    }


}
