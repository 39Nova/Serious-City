using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
public int gold;
public Text goldDisplay;

<<<<<<< Updated upstream

void Update()
{
    goldDisplay.text = gold.ToString();
}

=======
{
    public int gold;
    public Text goldDisplay;


   void Update()
    {
        goldDisplay.text = gold.ToString();
    }
>>>>>>> Stashed changes
}

