using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyMotion : MonoBehaviour
{
    private Quaternion _startRotation;
    private Quaternion _newRotation;

    public int secondsToRotateOnce = 60;
    public float latitude = 90f;
    [SerializeField] GameObject latitudeNull;
    private float latitudeSkyboxAngle; 

    // Start is called before the first frame update
    void Start()
    {
        _startRotation = transform.rotation;    
    }

    // Update is called once per frame
    void Update()
    {


        //rotate once in n seconds
        float rotationSpeed = 360f / (float)secondsToRotateOnce;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        _newRotation = transform.rotation;
        latitudeSkyboxAngle = 90 - latitude;

        Quaternion quaternionRotationValue = Quaternion.Euler(latitudeSkyboxAngle, 0f, _newRotation.z);
        latitudeNull.transform.rotation = quaternionRotationValue;
        //_newRotation = transform.rotation;
        ////_newRotation.y += Mathf.Sin(Time.time) * Time.deltaTime;
        //_newRotation.y += Time.deltaTime;
        //transform.rotation = _newRotation;

    }
}
