using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Light theSunLight; 
    [SerializeField] Light theShadowLight;
    [SerializeField] GameObject equatorialPlaneGameObject;
    [SerializeField] GameObject backgroundImageGameObject;
    [SerializeField] GameObject zodiacalBeltGameObject1;
    [SerializeField] GameObject zodiacalBeltGameObject2;
    [SerializeField] GameObject zodiacalBeltGameObject3;
    [SerializeField] GameObject zodiacalBeltGameObject4;
    [SerializeField] GameObject zodiacalBeltGameObject5;
    private int zodiacCounter; 

    //[SerializeField] GameObject theSunLightGO;
    //[SerializeField] GameObject theShadowLightGO;

    ////settings 
    //[SerializeField] float sunIntensity;
    //[SerializeField] float shadowSideIntensity;


    // Start is called before the first frame update
    void Start()
    {
        ////settings
        //sunLight = theSunLight.GetComponent<Light>();
        //shadowLight = theShadowLight.GetComponent<Light>();
        //sunIntensity = 14;
        //shadowSideIntensity = 5;
        //sunLight.intensity = sunIntensity;
        //shadowLight.intensity = shadowSideIntensity;

        //turn off the equitorial plane to start with 
        equatorialPlaneGameObject.SetActive(false);
        backgroundImageGameObject.SetActive(false); 

        //make sure all the zodiac belts are inactive 
        zodiacalBeltGameObject1.SetActive(false);
        zodiacalBeltGameObject2.SetActive(false);
        zodiacalBeltGameObject3.SetActive(false);
        zodiacalBeltGameObject4.SetActive(false);
        zodiacalBeltGameObject5.SetActive(false);

        //set initial sun and shadow brightnesses
        theSunLight.intensity = 8; 
        theShadowLight.intensity = 3;

        //start with no ecliptic plane image
        zodiacCounter = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        ////settings
        //sunLight.intensity = sunIntensity;
        //shadowLight.intensity = shadowSideIntensity;
    }

    //video settings 
    public void setSunBrightness(System.Single sliderValue)
    {
        theSunLight.intensity = sliderValue;
    }
    public void setShadowBrightness(System.Single sliderValue)
    {
        theShadowLight.intensity = sliderValue;
    }

    public void toggleEquatorialPlane()
    {
        equatorialPlaneGameObject.SetActive(!equatorialPlaneGameObject.activeSelf);
    }
    public void toggleEclipticPlane()
    {
        //all inactive 
        zodiacalBeltGameObject1.SetActive(false);
        zodiacalBeltGameObject2.SetActive(false);
        zodiacalBeltGameObject3.SetActive(false);
        zodiacalBeltGameObject4.SetActive(false);
        zodiacalBeltGameObject5.SetActive(false);

        if (zodiacCounter == 5) { zodiacCounter = 0; } else { zodiacCounter++; } 

        if (zodiacCounter == 1) {zodiacalBeltGameObject1.SetActive(true);}
        if (zodiacCounter == 2) {zodiacalBeltGameObject2.SetActive(true);}
        if (zodiacCounter == 3) {zodiacalBeltGameObject3.SetActive(true);}
        if (zodiacCounter == 4) {zodiacalBeltGameObject4.SetActive(true);}
        if (zodiacCounter == 5) {zodiacalBeltGameObject5.SetActive(true);}
    }
    public void toggleBackgroundImage()
    {
        backgroundImageGameObject.SetActive(!backgroundImageGameObject.activeSelf);
    }
}
