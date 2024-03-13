using UnityEngine;

public class RotationCounter : MonoBehaviour
{
    [SerializeField] TimeController timeController;  
    private float totalYRotation = 0f;
    private float lastYAngle = 0f;
    private int completeRotations = 0;

    void Start()
    {
        // Initialize with the current rotation to avoid initial jump
        lastYAngle = transform.eulerAngles.y;
    }

    void Update()
    {
        float deltaYRotation = Mathf.DeltaAngle(lastYAngle, transform.eulerAngles.y);
        totalYRotation += deltaYRotation;

        // Check if a complete rotation has been made
        if (Mathf.Abs(totalYRotation) >= 360)
        {
            // Determine the number of complete rotations
            int rotations = Mathf.FloorToInt(Mathf.Abs(totalYRotation) / 360);
            completeRotations += rotations;

            // Debug log to show the rotation count
            Debug.Log("Complete Rotations on Y-Axis: " + completeRotations + " totalYRotation:" + totalYRotation);

            // Notify the time controller that another year has passed
            timeController.newYear(); 

            // Adjust totalYRotation to account for the complete rotations
            totalYRotation = totalYRotation % 360;
        }

        // Update lastYAngle for the next frame
        lastYAngle = transform.eulerAngles.y;
    }
}