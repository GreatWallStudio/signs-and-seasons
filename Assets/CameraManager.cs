using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform ageCameraTransform; 
    //[SerializeField] Transform yearCameraPosition; 
    //[SerializeField] Transform monthCameraPosition; 
    [SerializeField] Transform dayCameraTransform;
    [SerializeField] Transform seasonCameraTransform;
    private Transform activeCameraTransform; 

    void Start()
    {
        //start from the day camera position
        transform.SetPositionAndRotation(dayCameraTransform.position, dayCameraTransform.rotation);
    }

    public void changeCameraPosition(string newCameraPos)
    {
        if(newCameraPos == "Age")       { StartCoroutine(MoveCameraToAge()); }
        if (newCameraPos == "Season")   { StartCoroutine(MoveCameraToSeason()); }
        if(newCameraPos == "Day")       { StartCoroutine(MoveCameraToDay()); }
    }

    IEnumerator MoveCameraToDay()
    {
        //store the camera's current transform
        activeCameraTransform = this.transform;

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
    }
    IEnumerator MoveCameraToAge()
    {
        //store the camera's current transform
        activeCameraTransform = this.transform;

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
    }


}
 