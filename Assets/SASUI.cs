using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SASUI : MonoBehaviour
{
    [SerializeField] TMP_Text displayDaysEllapsed;
    [SerializeField] int daysEllapsedValue;

    void Start()
    {
        displayDaysEllapsed.SetText(daysEllapsedValue.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateDaysDisplay(int CountOfDays)
    {
        displayDaysEllapsed.SetText("Days: " + CountOfDays.ToString());
    }
}