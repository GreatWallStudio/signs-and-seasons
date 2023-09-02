using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendTimeController : MonoBehaviour
{
    [SerializeField] GameObject theEarthContainer; 
    [SerializeField] GameObject theSunOrbit;
    [SerializeField] GameObject theMoonOrbit;
    [SerializeField] float timeShift;
    private float _MONTH = 27.3215277777777778f; 
    [SerializeField] List<string> rateOfTime = new List<string>(); 


    void Start()
    {
        rateOfTime.Add("Second");
        rateOfTime.Add("minute");
        rateOfTime.Add("hour");
        rateOfTime.Add("day");
        rateOfTime.Add("month");
        rateOfTime.Add("year");
        rateOfTime.Add("centery");
        rateOfTime.Add("millenium");
        timeShift = _MONTH; 
    }

// Update is called once per frame
void Update()
    {
        float earthRotationDegreesPerSecond = -1f;
        float sunRotationDegreesPerSecond = earthRotationDegreesPerSecond / 365.25f; 
        float moonRotationDegreesPerSecond = earthRotationDegreesPerSecond / _MONTH; 

        theEarthContainer.transform.Rotate(0, earthRotationDegreesPerSecond * timeShift, 0);
        theSunOrbit.transform.Rotate(0, sunRotationDegreesPerSecond * timeShift, 0); 
        theMoonOrbit.transform.Rotate(0, moonRotationDegreesPerSecond * timeShift, 0); 
    }
}
