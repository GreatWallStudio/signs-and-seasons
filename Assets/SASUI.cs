using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SASUI : MonoBehaviour
{
    [SerializeField] TMP_Text displayDaysEllapsed;
    [SerializeField] TMP_Text displayYearsEllapsed;
    [SerializeField] TMP_Text displayHMSEllapsed;
    [SerializeField] int daysEllapsedValue;

    void Start()
    {
        displayDaysEllapsed.SetText(daysEllapsedValue.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateYearsDisplay(int CountOfYears)
    {
        displayYearsEllapsed.SetText("Years: " + CountOfYears.ToString());
    }
    public void updateDaysDisplay(int CountOfDays)
    {
        displayDaysEllapsed.SetText("Days: " + CountOfDays.ToString());
    }
    public void updateHoursDisplay(string hms)
    {
        displayHMSEllapsed.SetText($"Hour: {hms}");
    }
}