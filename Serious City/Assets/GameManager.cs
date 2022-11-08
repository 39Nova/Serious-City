using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
public int gold;
public Text goldDisplay;

//Testing to see if this changes anything

void Update()
{
    goldDisplay.text = gold.ToString();
}

}

