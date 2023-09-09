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
    [SerializeField] GameObject menu; 
    [SerializeField] GameObject toggleMenuOn; 
    [SerializeField] PanelManager panelManager; 

    void Start()
    {
        //initialize the days display
        displayDaysEllapsed.SetText(daysEllapsedValue.ToString());
        
        //start with the menu off toggle hidden
        toggleMenuOn.SetActive(false); 
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