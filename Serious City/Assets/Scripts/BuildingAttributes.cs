using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAttributes : MonoBehaviour
{

    public int PollutionVal;
    public int MoneyVal;
    public static MoneySystem MoneyLvl;
    public MoneySystem other;

    // Start is called before the first frame update
    void Start()
    {

       //other = GameObject.Find("MoneySystem").GetComponent<MoneySystem>();
       //MoneySystem.MoneyLvl--;
       //other.SetMoney(MoneyVal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
