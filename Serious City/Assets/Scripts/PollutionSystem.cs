using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionSystem : MonoBehaviour
{

    public Slider slider;
    public static float PollutionLvl;
    public float PollutionBarLvl;
    public GameObject PollutionMeter;

    public Sprite Healthy;
    public Sprite Unsafe;
    public Sprite Severe;
    public Sprite Dire;

    public void SetPollution(float PollutionLvl)
    {
        PollutionBarLvl = PollutionBarLvl + PollutionLvl;
        slider.value = PollutionBarLvl;
        if (PollutionBarLvl >=0 && PollutionBarLvl < 25)
        {
            Debug.Log("Healthy");
            PollutionMeter.GetComponent<Image>().sprite = Healthy;
        }
        else if (PollutionBarLvl >= 25 && PollutionBarLvl < 50) 
        {
            Debug.Log("Unsafe");
            PollutionMeter.GetComponent<Image>().sprite = Unsafe;
        }
        else if (PollutionBarLvl >= 50 && PollutionBarLvl < 75)
        {
            Debug.Log("Severe");
            PollutionMeter.GetComponent<Image>().sprite = Severe;
        }
        else if (PollutionBarLvl >= 75 && PollutionBarLvl <= 100)
        {
            Debug.Log("Dire");
            PollutionMeter.GetComponent<Image>().sprite = Dire;
        }
    }

}
