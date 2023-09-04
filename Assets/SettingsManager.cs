using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Light theSunLight; 
    [SerializeField] Light theShadowLight;

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

        theSunLight.intensity = 8; 
        theShadowLight.intensity = 3; 
    }

    // Update is called once per frame
    void Update()
    {
        ////settings
        //sunLight.intensity = sunIntensity;
        //shadowLight.intensity = shadowSideIntensity;
    }

    public void setSunBrightness(System.Single sliderValue)
    {
        theSunLight.intensity = sliderValue;
        Debug.Log($"sun intensity sliderValue = {sliderValue}");
    }
    public void setShadowBrightness(System.Single sliderValue)
    {
        theShadowLight.intensity = sliderValue;
        Debug.Log($"shadow intensity sliderValue = {sliderValue}");
    }
}
