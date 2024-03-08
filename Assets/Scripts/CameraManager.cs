using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform ageCameraTransform; 
    [SerializeField] Transform overheadCameraTransform; 
    //[SerializeField] Transform monthCameraPosition; 
    [SerializeField] Transform dayCameraTransform;
    [SerializeField] Transform seasonCameraTransform;
    [SerializeField] Transform geocentricCameraTransform;
    private Transform activeCameraTransform;
    private string cameraPositon; 
    private bool movingCamera; 
    private bool movingCameraSwitch; 

    void Start()
    {
        //start from the day camera position
        transform.SetPositionAndRotation(dayCameraTransform.position, dayCameraTransform.rotation);
        cameraPositon = "Overhead";
        transform.SetPositionAndRotation(overheadCameraTransform.transform.position, overheadCameraTransform.transform.rotation);
        movingCamera = false;
        movingCameraSwitch = false;
    }

    private void Update()
    {
        if (movingCamera)
        {
            if (cameraPositon == "Age") {
                transform.SetPositionAndRotation(ageCameraTransform.transform.position, ageCameraTransform.transform.rotation);
            }
            if (cameraPositon == "Season") {
                transform.SetPositionAndRotation(seasonCameraTransform.transform.position, seasonCameraTransform.transform.rotation);
            }
            if (cameraPositon == "Day") {
                transform.SetPositionAndRotation(dayCameraTransform.transform.position, dayCameraTransform.transform.rotation);
            }
            if (cameraPositon == "Geocentric") {
                transform.SetPositionAndRotation(geocentricCameraTransform.transform.position, geocentricCameraTransform.transform.rotation);
            }
        }
    }

    public void changeCameraPosition(string newCameraPos)
    {
        movingCamera = false; 
        if(newCameraPos == "Age")       { 
            StartCoroutine(MoveCameraToAge());
            Camera.main.orthographicSize = 10;
        }
        if (newCameraPos == "Overhead")      { 
            StartCoroutine(MoveCameraToOverhead());
            Camera.main.orthographicSize = 10;
        }
        if(newCameraPos == "Day")       { 
            StartCoroutine(MoveCameraToDay());
            Camera.main.orthographicSize = 10;
        }
        if(newCameraPos == "Season")       { 
            StartCoroutine(MoveCameraToSeason());
            Camera.main.orthographicSize = 4;
        }
        if(newCameraPos == "Geocentric")       { 
            StartCoroutine(MoveCameraToGeocentric());
            Camera.main.orthographicSize = 18;
        }
    }

    IEnumerator MoveCameraToAge()
    {
        //store the camera's current transform
        activeCameraTransform = this.transform;
        //Camera.main.orthographic = true;

        //t value for lerps and loop
        float t = 0;

        while (t < 1.01)
        {
            yield return new WaitForSeconds(.03f);

            transform.SetPositionAndRotation(Vector3.Lerp(activeCameraTransform.position, ageCameraTransform.transform.position, t),
            Quaternion.Lerp(activeCameraTransform.rotation, ageCameraTransform.transform.rotation, t));
            t = t + .01f;
        }
        activeCameraTransform = this.transform;
        cameraPositon = "Age";
        movingCamera = movingCameraSwitch;
    }

    IEnumerator MoveCameraToSeason()
    {
        //store the camera's current transform
        activeCameraTransform = this.transform;

        //t value for lerps and loop
        float t = 0;

        while (t < 1.01)
        {
            yield return new WaitForSeconds(.03f);

            transform.SetPositionAndRotation(Vector3.Lerp(activeCameraTransform.position, seasonCameraTransform.transform.position, t),
            Quaternion.Lerp(activeCameraTransform.rotation, seasonCameraTransform.transform.rotation, t));
            t = t + .01f;
        }
        activeCameraTransform = this.transform;
        cameraPositon = "Season";
        movingCamera = movingCameraSwitch;
    }
    
    IEnumerator MoveCameraToDay()
    {
        //store the camera's current transform
        activeCameraTransform = this.transform;
        //Camera.main.orthographic = false;

        //t value for lerps and loop
        float t = 0;

        while (t < 1.01)
        {
            yield return new WaitForSeconds(.03f);

            transform.SetPositionAndRotation(Vector3.Lerp(activeCameraTransform.position, dayCameraTransform.transform.position, t),
            Quaternion.Lerp(activeCameraTransform.rotation, dayCameraTransform.transform.rotation, t));
            t = t + .01f;
        }
        activeCameraTransform = this.transform;
        cameraPositon = "Day";
        movingCamera = movingCameraSwitch;
    }
    IEnumerator MoveCameraToGeocentric()
    {
        //store the camera's current transform
        activeCameraTransform = this.transform;
        //Camera.main.orthographic = true;

        //t value for lerps and loop
        float t = 0;

        while (t < 1.01)
        {
            yield return new WaitForSeconds(.03f);

            transform.SetPositionAndRotation(Vector3.Lerp(activeCameraTransform.position, geocentricCameraTransform.transform.position, t),
            Quaternion.Lerp(activeCameraTransform.rotation, geocentricCameraTransform.transform.rotation, t));
            t = t + .01f;
        }
        activeCameraTransform = this.transform;
        cameraPositon = "Geocentric";
        movingCamera = movingCameraSwitch;
    }
    IEnumerator MoveCameraToOverhead()
    {
        //store the camera's current transform
        activeCameraTransform = this.transform;
        //Camera.main.orthographic = true;

        //t value for lerps and loop
        float t = 0;

        while (t < 1.01)
        {
            yield return new WaitForSeconds(.03f);

            transform.SetPositionAndRotation(Vector3.Lerp(activeCameraTransform.position, overheadCameraTransform.transform.position, t),
            Quaternion.Lerp(activeCameraTransform.rotation, overheadCameraTransform.transform.rotation, t));
            t = t + .01f;
        }
        activeCameraTransform = this.transform;
        cameraPositon = "Overhead";
        movingCamera = movingCameraSwitch;
    }

    public void fly()
    {
        movingCameraSwitch = !movingCameraSwitch;
        movingCamera = movingCameraSwitch; 
    }
}
 