using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    [SerializeField] Transform geocentricCameraTransform; 
    [SerializeField] Transform cameraTransform;
    [SerializeField] int speed;
    [SerializeField] LayerMask worldLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movementDirection = Vector3.zero;
        //if (Input.GetAxisRaw("Vertical") > 0)
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            geocentricCameraTransform.Rotate(Vector3.right * -30 * Time.deltaTime, Space.Self);
            movementDirection += cameraTransform.up;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            geocentricCameraTransform.Rotate(Vector3.right * 30 * Time.deltaTime, Space.Self);
            movementDirection += -cameraTransform.up;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * 30 * Time.deltaTime, Space.Self);
            movementDirection += cameraTransform.right;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            movementDirection += -cameraTransform.right;
            transform.Rotate(Vector3.up * -30 * Time.deltaTime, Space.Self);
        }

        movementDirection.Normalize();

        //UpdatePlayerTransform(movementDirection);
    }

    private void UpdatePlayerTransform(Vector3 movementDirection)
    {
        RaycastHit hitInfo;

        if (GetRaycastDownAtNewPosition(movementDirection, out hitInfo))
        {
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, float.PositiveInfinity);

            transform.rotation = finalRotation;
            transform.position = hitInfo.point + hitInfo.normal * .5f;
        }
    }

    private bool GetRaycastDownAtNewPosition(Vector3 movementDirection, out RaycastHit hitInfo)
    {
        Vector3 newPosition = transform.position;
        Ray ray = new Ray(transform.position + movementDirection * speed, -transform.up);

        if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, worldLayerMask))
        {
            return true;
        }

        return false;
    }
}
