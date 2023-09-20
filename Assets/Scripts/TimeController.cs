using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeController : MonoBehaviour
{
    [SerializeField] GameObject sliderObject;
    [SerializeField] Slider sliderComponent;
    [SerializeField] float sliderValue;
    [SerializeField] GameObject uITimeElements; 
    [SerializeField] GameObject theZodiac; 
    [SerializeField] GameObject theEarth;
    [SerializeField] Quaternion theEarthOrigRotation; 
    [SerializeField] GameObject theEarthContainer; 
    [SerializeField] GameObject theSun;
    [SerializeField] GameObject theMoon;
    [SerializeField] GameObject theMoonContainer;
    [SerializeField] GameObject theMoonPosition;   

    [SerializeField] Vector3 theSunRotationSpringEquinox; 
    [SerializeField] Vector3 theSunRotationSummerSolstice; 
    [SerializeField] Vector3 theSunRotationAutumnalEquinox; 
    [SerializeField] Vector3 theSunRotationWinterSolstice; 


    [SerializeField] SASUI SASuserInterface; 

    //this is the angle the earth moves around the sun  ...in one year
    [SerializeField] float timeMultiplier;

    [SerializeField] float greatYearAngle;
    [SerializeField] float ageAngle;
    [SerializeField] float precessionYearsPerDegree;
    [SerializeField] float precessionOfTheSunAngleInYear;
    [SerializeField] float precessionOfTheSunAngleInDay;
    [SerializeField] float precessionOfTheSunAngleInHour;
    [SerializeField] float precessionOfTheSunAngleInMinute;
    [SerializeField] float precessionOfTheSunAngleInSecond;

    [SerializeField] float earthAroundSunAngleInYear;
    [SerializeField] float earthAroundSunAngleInMonth;
    [SerializeField] float earthAroundSunAngleInDay;
    [SerializeField] float earthAroundSunAngleInHour;
    [SerializeField] float earthAroundSunAngleInMinute;
    [SerializeField] float earthAroundSunAngleInSecond;

    [SerializeField] float earthRotationAngleInDay;
    [SerializeField] float earthRotationAngleInHour;
    [SerializeField] float earthRotationAngleInMinute;
    //[SerializeField] float earthRotationAngleInSeconds;
    [SerializeField] float moonAroundEarthAngleInMonth;
    [SerializeField] float moonAroundEarthAngleInDay;
    [SerializeField] float moonAroundEarthAngleInHour;
    [SerializeField] float moonAroundEarthAngleInMinute;
    [SerializeField] float moonAroundEarthAngleInSecond;
    //[SerializeField] float second;
    //[SerializeField] float minute;
    //[SerializeField] float hour;
    //[SerializeField] float day;
    //[SerializeField] float week;
    [SerializeField] string hh;

    GameObject springEquinoxEarth; 
    GameObject summerSolsticeEarth; 
    GameObject autumnalEquinoxEarth; 
    GameObject winterSolsticeEarth; 

    void Start()
    {
        //this is the precession of the equinoxes - one full rotation in 25,800 years
        greatYearAngle = -360;
        ageAngle = greatYearAngle / 12;
        precessionYearsPerDegree = 25800 / 360;
        precessionOfTheSunAngleInYear = greatYearAngle / 25800;
        precessionOfTheSunAngleInDay = precessionOfTheSunAngleInYear / 360;
        precessionOfTheSunAngleInHour = precessionOfTheSunAngleInDay / 24;
        precessionOfTheSunAngleInMinute = precessionOfTheSunAngleInHour / 60;
        precessionOfTheSunAngleInSecond = precessionOfTheSunAngleInMinute / 60; 

        //this is the angle the earth revolves around the sun  
        earthAroundSunAngleInYear = -360;                               // ...in one year
        earthAroundSunAngleInMonth = earthAroundSunAngleInYear / 12;    // ...in one month  
        earthAroundSunAngleInDay = earthAroundSunAngleInMonth / 30;     // ...in one day     
        earthAroundSunAngleInHour = earthAroundSunAngleInDay / 25;      // ...in one hour
        earthAroundSunAngleInMinute = earthAroundSunAngleInHour / 60;   // ...in one minute
        earthAroundSunAngleInSecond = earthAroundSunAngleInMinute / 60; // ...in one second
        theEarthOrigRotation = theEarth.transform.rotation; 

        //store the solsticial and equinoctial position of earth...
        //these are the angles of the sun's rotation in degrees
        //theSunRotationSpringEquinox = theSun.transform.localEulerAngles;  
        theSunRotationSpringEquinox.y = theSun.transform.localEulerAngles.y + 20;  
        theSunRotationSummerSolstice.y = theSun.transform.localEulerAngles.y + 270;  
        theSunRotationAutumnalEquinox.y = theSun.transform.localEulerAngles.y + 180; 
        theSunRotationWinterSolstice.y = theSun.transform.localEulerAngles.y + 90; 

        //this is the angle the earth rotates around its axis
        earthRotationAngleInDay = -360;
        earthRotationAngleInHour = earthRotationAngleInDay / 24;
        earthRotationAngleInMinute = earthRotationAngleInHour / 60;
        //earthRotationAngleInSeconds = earthRotationAngleInMinute / 60;

        //this is the angle the moon revolves around the earth 
        moonAroundEarthAngleInMonth = -360;//(27 * earthAroundSunAngleInDay) + (7 * earthAroundSunAngleInHour) + (43 * earthAroundSunAngleInMinute);
        moonAroundEarthAngleInDay = moonAroundEarthAngleInMonth / 30;
        moonAroundEarthAngleInHour = moonAroundEarthAngleInDay / 24;
        moonAroundEarthAngleInMinute = moonAroundEarthAngleInHour / 60;
        moonAroundEarthAngleInSecond = moonAroundEarthAngleInMinute / 60;

        ////time is defined since start of game
        ////time in seconds since the start of the game
        //second = Time.fixedUnscaledTime;
        //minute = 60 * second;
        //hour = 60 * minute;
        //day = 24 * earthAroundSunAngleInHour;
        //week = 7 * earthAroundSunAngleInDay;
        instantiateSeasonalEarths();
    }

// Update is called once per frame
void Update()
    {
        //timeMultiplier = 1 * Mathf.Exp(sliderComponent.value);

        ////time in seconds since the start of the game
        //second = Time.fixedUnscaledTime;

        //this rotates the zodiac, which rotates the zodiac's position
        theZodiac.transform.Rotate(0, precessionOfTheSunAngleInSecond * timeMultiplier * Time.deltaTime, 0);

        //this rotates the sun, which rotates the earth's position
        float earthRevolutionAmount = earthAroundSunAngleInSecond * timeMultiplier * Time.deltaTime; 
        theSun.transform.Rotate(0, earthRevolutionAmount, 0);

        //set the position of the earth but leave its rotation alone
        theEarth.transform.SetPositionAndRotation(theEarthContainer.transform.position, theEarth.transform.rotation);

        //when the earth gets to the equinoctial and solsticial points, show the hidden earths at those positions
        //eventually make this controlled by a button 
        Debug.Log(theEarthContainer.transform.position);
        if (Mathf.Round(theEarthContainer.transform.position.x) == -15 && Mathf.Round(theEarthContainer.transform.position.z) == 0)
        {
            summerSolsticeEarth.SetActive(true);
        }
        if (Mathf.Round(theEarthContainer.transform.position.x) == 0 && Mathf.Round(theEarthContainer.transform.position.z) == -15)
        {
            autumnalEquinoxEarth.SetActive(true);
        }
        if (Mathf.Round(theEarthContainer.transform.position.x) == 15 && Mathf.Round(theEarthContainer.transform.position.z) == 0)
        {
            winterSolsticeEarth.SetActive(true);
        }


        //this rotates the earth around its axis
        //one time for every degree the earth revolves around the sun
        float earthRotationAmount = earthRevolutionAmount * 360; 
        theEarth.transform.Rotate(0, earthRotationAmount, 0);

        //once the solsticial and equinoctial earths are visible, make them spin
        if (springEquinoxEarth != null)
        {
            springEquinoxEarth.transform.Rotate(0, earthRotationAmount, 0); 
        }
        if (summerSolsticeEarth != null)
        {
            summerSolsticeEarth.transform.Rotate(0, earthRotationAmount, 0); 
        }
        if (autumnalEquinoxEarth != null)
        {
            autumnalEquinoxEarth.transform.Rotate(0, earthRotationAmount, 0); 
        }
        if (winterSolsticeEarth != null)
        {
            winterSolsticeEarth.transform.Rotate(0, earthRotationAmount, 0); 
        }

        //theEarth.transform.Rotate(0, earthRotationAngleInSeconds * timeMultiplier * Time.deltaTime, 0);

        //rotate the moons container
        theMoonContainer.transform.Rotate(0, moonAroundEarthAngleInSecond * timeMultiplier * Time.deltaTime, 0);

        //set the position of the moon but leave its rotation alone 
        theMoon.transform.SetPositionAndRotation(theMoonPosition.transform.position, theMoon.transform.rotation);

        //update the day counter
        SASuserInterface.updateDaysDisplay(359 - (int) Mathf.Floor(theSun.transform.eulerAngles.y));

        //update the hour, minute, second counter
        if (theEarth.transform.eulerAngles.y > 0 ) {
            hh = (24 - (int)Mathf.Round(theEarth.transform.eulerAngles.y) / 15).ToString();
        } else
        {
            hh = "1"; 
        }
        //mm = (3500 - (int)Mathf.Round(theEarth.transform.eulerAngles.y)/(0.1f)).ToString();
        //ss = "00"; 

        SASuserInterface.updateHoursDisplay(hh);

        //update the year counter - this is klugey fer shur
        if (theZodiac.transform.eulerAngles.y < 0.008f)
        {
            SASuserInterface.updateYearsDisplay(0);
        }
        else
        {
            SASuserInterface.updateYearsDisplay(25800 - 241 - (int)Mathf.Floor(((theZodiac.transform.eulerAngles.y) * precessionYearsPerDegree)));
        }

    }

    public void instantiateSeasonalEarths()
    {
        springEquinoxEarth = GameObject.Instantiate(theEarth);
        summerSolsticeEarth = GameObject.Instantiate(theEarth);
        autumnalEquinoxEarth = GameObject.Instantiate(theEarth);
        winterSolsticeEarth = GameObject.Instantiate(theEarth);
        springEquinoxEarth.transform.position = new Vector3(0, 0, 15);
        summerSolsticeEarth.transform.position = new Vector3(-15, 0, 0);
        autumnalEquinoxEarth.transform.position = new Vector3(0, 0, -15);
        winterSolsticeEarth.transform.position = new Vector3(15, 0, 0);
        summerSolsticeEarth.SetActive(false);
        autumnalEquinoxEarth.SetActive(false);
        winterSolsticeEarth.SetActive(false);
    }

    public void setTimeMultiplier (System.Single sliderValue)
    {
        timeMultiplier = 10 * Mathf.Exp(sliderValue); 
        Debug.Log($"timeMultiplier {timeMultiplier} and sliderValue = {sliderValue}");
    }

    public void gotoSeason(string season)
    {
        //the earth's position is a child of the sun.
        //By rotating the sun to 90 degree intervals,
        //the earth's position moves to the solsticial and equinoctial points
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
        theEarth.transform.SetPositionAndRotation(new Vector3(theEarth.transform.position.x, theEarth.transform.position.y, theEarth.transform.position.z), theEarthOrigRotation);  
    }
}
