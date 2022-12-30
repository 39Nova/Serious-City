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
    public float MoneyLvl;
    public float MoneyPD;
    List<GameObject> Pollutants;
    List<GameObject> Moneys;



    // Start is called before the first frame update
    void Start()
    {
        Pollutants = GameObject.Find("Grid").GetComponent<BuildingSystem>().Pollutants;
        Moneys = GameObject.Find("Grid").GetComponent<BuildingSystem>().MoneySpenders;
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
        GameObject.Find("PollutionSystem").GetComponent<PollutionSystem>().SetPollution(PollutionLvl);

        GameObject.Find("MoneySystem").GetComponent<MoneySystem>().SetMoney(MoneyLvl);

        DayTimer = DayLength;
    }
        public void UpdatePollution()
    {
        PollutionLvl = 0;

        for (int i = 0; i < Pollutants.Count; i++)
        {
            PollutionLvl = PollutionLvl + Pollutants[i].GetComponent<BuildingAttributes>().PollutionVal;
        }
    }
    public void UpdateMoney()
    {
        MoneyLvl = 0;
        
        for (int i = 0; i < Pollutants.Count; i++)
        {
            MoneyLvl = MoneyLvl + Moneys[i].GetComponent<BuildingAttributes>().MoneyVal;
        }
    }
}
