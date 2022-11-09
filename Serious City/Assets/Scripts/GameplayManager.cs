using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public int DayNumber = 1;
    private float DayTimer;
    public float DayLength;
    public float MaxDayCount;
    private bool TimePasses = true;
    public float PollutionLvl;
    public float PollutionPD;
    List<GameObject> Pollutants;



    // Start is called before the first frame update
    void Start()
    {
        Pollutants = GameObject.Find("Grid").GetComponent<BuildingSystem>().Pollutants;
        DayTimer = DayLength;
        UpdateDay.DayNumber = DayNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(DayTimer > 0 && TimePasses == true)
        {
            DayTimer -= Time.deltaTime;
        }
        else if (DayTimer <= 0 && TimePasses == true)
        {
            if(DayNumber == MaxDayCount)
            {
                TimePasses = false;
                Debug.Log("Game Over");
            }
            else
            {
                DayTurnover();
            }
        }
    }
    void DayTurnover()
    {
        DayNumber = DayNumber + 1;
        UpdateDay.DayNumber = DayNumber;
        PollutionLvl = PollutionLvl + 10;
        GameObject.FindGameObjectWithTag("PollutionSystem").GetComponent<PollutionSystem>().SetPollution(PollutionLvl);
        DayTimer = DayLength;
    }

    void UpdatePollution()
    {
        for (int i = 0; i < Pollutants.Count; i++)
        {
            PollutionPD = PollutionPD + Pollutants[i].GetComponent<BuildingAttributes>().PollutionVal;
        }
        //PollutionPD
    }
}
