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
    //[SerializeField] GameObject menuGameObject;
    //[SerializeField] int camMoveSpeed;
    //private string activeCamera;
    //private bool cameraIsMoving;
    private float t; 

    void Start()
    {
        //start from the day camera position
        transform.SetPositionAndRotation(dayCameraTransform.position, dayCameraTransform.rotation);
        //cameraIsMoving = false;
        //t = 0; 
    }

    void Update()
    {

    }

    public void changeCameraPosition(string cameraChangedTo)
    {
        if(cameraChangedTo == "Age")
        {
            transform.SetPositionAndRotation(ageCameraTransform.position, ageCameraTransform.rotation);
        }
        if(cameraChangedTo == "Season")
        {
            transform.SetPositionAndRotation(seasonCameraTransform.position, seasonCameraTransform.rotation);
        }
        if(cameraChangedTo == "Day")
        {
            transform.SetPositionAndRotation(dayCameraTransform.position, dayCameraTransform.rotation);
        }
        Debug.Log($"changeCameraPosition called and cameraChangedTo = {cameraChangedTo}");
    }
}
