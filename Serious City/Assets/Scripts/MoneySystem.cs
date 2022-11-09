using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{

    public Slider slider;
    public static float MoneyLvl;

    public void SetMoney(float MoneyLvl)
    {
        Debug.Log(MoneyLvl);
        slider.value = MoneyLvl;
    }

    //work damnit


}
