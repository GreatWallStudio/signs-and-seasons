using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeController : MonoBehaviour
{
    [SerializeField] GameObject theEarth; 
    [SerializeField] GameObject theEarthContainer; 
     [SerializeField] GameObject theSun;
    [SerializeField] GameObject theMoon;
    [SerializeField] GameObject theMoonContainer;
    [SerializeField] GameObject theMoonPosition;   

    [SerializeField] Vector3 theSunRotationSpringEquinox; 
    [SerializeField] Vector3 theSunRotationSummerSolstice; 
    [SerializeField] Vector3 theSunRotationAutumnalEquinox; 
    [SerializeField] Vector3 theSunRotationWinterSolstice; 

    [SerializeField] GameObject theSunLight;
    [SerializeField] GameObject theShadowLight;

    [SerializeField] SASUI SASuserInterface; 

    //[SerializeField] float timeShift;
    //private float _MONTH = 27.3215277777777778f; 
    //[SerializeField] List<string> rateOfTime = new List<string>();

    //this is the angle the earth moves around the sun  ...in one year
    [SerializeField] float timeMultiplier;
    [SerializeField] float earthAroundSunAngleInYear;
    [SerializeField] float earthAroundSunAngleInMonth;
    [SerializeField] float earthAroundSunAngleInDay;
    [SerializeField] float earthAroundSunAngleInHour;
    [SerializeField] float earthAroundSunAngleInMinute;
    [SerializeField] float earthAroundSunAngleInSecond;
    [SerializeField] float earthRotationAngleInDay;
    [SerializeField] float earthRotationAngleInHour;
    [SerializeField] float earthRotationAngleInMinute;
    [SerializeField] float earthRotationAngleInSeconds;
    [SerializeField] float moonAroundEarthAngleInMonth;
    [SerializeField] float moonAroundEarthAngleInDay;
    [SerializeField] float moonAroundEarthAngleInHour;
    [SerializeField] float moonAroundEarthAngleInMinute;
    [SerializeField] float moonAroundEarthAngleInSecond;
    [SerializeField] float second;
    [SerializeField] float minute;
    [SerializeField] float hour;
    [SerializeField] float day;
    [SerializeField] float week;

    //settings 
    [SerializeField] float sunIntensity; 
    [SerializeField] float shadowSideIntensity; 
    Light sunLight; 
    Light shadowLight; 


    void Start()
    {

        //this is the angle the earth revolves around the sun  
        earthAroundSunAngleInYear = -360;                               // ...in one year
        earthAroundSunAngleInMonth = earthAroundSunAngleInYear / 12;    // ...in one month  
        earthAroundSunAngleInDay = earthAroundSunAngleInMonth / 30;     // ...in one day     
        earthAroundSunAngleInHour = earthAroundSunAngleInDay / 25;      // ...in one hour
        earthAroundSunAngleInMinute = earthAroundSunAngleInHour / 60;   // ...in one minute
        earthAroundSunAngleInSecond = earthAroundSunAngleInMinute / 60; // ...in one second

        //store the solsticial and equinoctial position of earth...
        //these are the angles of the sun's rotation in degrees
        theSunRotationSpringEquinox = theSun.transform.localEulerAngles;  
        theSunRotationSummerSolstice.y = theSun.transform.localEulerAngles.y + 270;  
        theSunRotationAutumnalEquinox.y = theSun.transform.localEulerAngles.y + 180; 
        theSunRotationWinterSolstice.y = theSun.transform.localEulerAngles.y + 90; 


        //this is the angle the earth rotates around its axis
        earthRotationAngleInDay = -360;
        earthRotationAngleInHour = earthRotationAngleInDay / 24;
        earthRotationAngleInMinute = earthRotationAngleInHour / 60;
        earthRotationAngleInSeconds = earthRotationAngleInMinute / 60;

        //this is the angle the moon revolves around the earth 
        moonAroundEarthAngleInMonth = -360;//(27 * earthAroundSunAngleInDay) + (7 * earthAroundSunAngleInHour) + (43 * earthAroundSunAngleInMinute);
        moonAroundEarthAngleInDay = moonAroundEarthAngleInMonth / 30;
        moonAroundEarthAngleInHour = moonAroundEarthAngleInDay / 24;
        moonAroundEarthAngleInMinute = moonAroundEarthAngleInHour / 60;
        moonAroundEarthAngleInSecond = moonAroundEarthAngleInMinute / 60; 

        //time is defined since start of game
        //time in seconds since the start of the game
        second = Time.fixedUnscaledTime;
        minute = 60 * second;
        hour = 60 * minute;
        day = 24 * earthAroundSunAngleInHour;
        week = 7 * earthAroundSunAngleInDay;

        //settings
        sunLight = theSunLight.GetComponent<Light>();
        shadowLight = theShadowLight.GetComponent<Light>();
        sunIntensity = 14;
        shadowSideIntensity = 5; 
        sunLight.intensity = sunIntensity;
        shadowLight.intensity = shadowSideIntensity; 
    }

// Update is called once per frame
void Update()
    {
        //settings
        sunLight.intensity = sunIntensity;
        shadowLight.intensity = shadowSideIntensity;

        //time in seconds since the start of the game
        second = Time.fixedUnscaledTime;
        
        //this rotates the sun, which rotates the earth's position
        theSun.transform.Rotate(0, earthAroundSunAngleInSecond * timeMultiplier * Time.deltaTime, 0);

        //set the position of the earth but leave its rotation alone
        theEarth.transform.SetPositionAndRotation(theEarthContainer.transform.position, theEarth.transform.rotation); 

        //this rotates the earth around its axis
        theEarth.transform.Rotate(0, earthRotationAngleInSeconds * timeMultiplier * Time.deltaTime, 0);

        //rotate the moons container
        theMoonContainer.transform.Rotate(0, moonAroundEarthAngleInSecond * timeMultiplier * Time.deltaTime, 0);

        //set the position of the moon but leave its rotation alone 
        theMoon.transform.SetPositionAndRotation(theMoonPosition.transform.position, theMoon.transform.rotation);

        //update the day counter
        SASuserInterface.updateDaysDisplay(359 - (int) Mathf.Floor(theSun.transform.eulerAngles.y));

    }

    public void gotoSeason(string season)
    {
        if (season == "Vernal Equinox")
        {
            theSun.transform.SetPositionAndRotation(theSun.transform.position, Quaternion.Euler(theSunRotationSpringEquinox));
        }
        if (season == "Summer Solstice")
        {
            theSun.transform.SetPositionAndRotation(theSun.transform.position, Quaternion.Euler(theSunRotationSummerSolstice));
        }
        if (season == "Autumnal Equinox")
        {
            theSun.transform.SetPositionAndRotation(theSun.transform.position, Quaternion.Euler(theSunRotationAutumnalEquinox));
        }
        if (season == "Winter Solstice")
        {
            theSun.transform.SetPositionAndRotation(theSun.transform.position, Quaternion.Euler(theSunRotationWinterSolstice));
        }
    }
}
