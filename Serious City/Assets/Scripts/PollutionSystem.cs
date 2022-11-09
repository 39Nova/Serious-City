using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionSystem : MonoBehaviour
{

    public Slider slider;
    public static float PollutionLvl;

    public void SetPollution(float PollutionLvl)
    {
        Debug.Log(PollutionLvl);
        slider.value = PollutionLvl;
    }

}
