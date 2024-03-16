using UnityEngine;

public class RotationCounter : MonoBehaviour
{
    [SerializeField] TimeController timeController;
    [SerializeField] Transform zodiacTransform;
    [SerializeField] SASUI sASUI;
    private float totalYRotation = 0f;
    private float lastYAngle = 0f;
    private int completeRotations = 0;
    private float deltaTime;
    private bool recalcYear; 

    void Start()
    {
        deltaTime = Time.time; 
        // Initialize with the current rotation to avoid initial jump
        lastYAngle = transform.eulerAngles.y;
        recalcYear = false; 
    }

    void FixedUpdate()
    {
        float deltaYRotation = Mathf.DeltaAngle(lastYAngle, transform.eulerAngles.y);
        totalYRotation += deltaYRotation;

        // Check if it's spinning too fast
        if (Mathf.Abs(totalYRotation) >= 370)
        {
            // Determine the number of complete rotations
            int rotations = Mathf.FloorToInt(Mathf.Abs(totalYRotation) / 360);
            completeRotations += rotations;
            
            //timeController.setYear((int)Mathf.Floor(zodiacTransform.rotation.y / timeController.precessionOfTheSunAngleInYear));
            Debug.Log("<color=red>Error: </color>dropping years");
            Debug.Log("zodiacTransform.rotation.y" + zodiacTransform.rotation.y);
            Debug.Log("timeController.precessionOfTheSunAngleInYear" + timeController.precessionOfTheSunAngleInYear);
            Debug.Log("(int)Mathf.Floor(zodiacTransform.rotation.y / timeController.precessionOfTheSunAngleInYear)" + (int)Mathf.Floor(zodiacTransform.rotation.y / timeController.precessionOfTheSunAngleInYear));
            // Adjust totalYRotation to account for the complete rotations

            sASUI.blurYear=true; 
            recalcYear = true;

            // Adjust totalYRotation to account for the complete rotations
            totalYRotation = totalYRotation % 360;
        } 
        else if (Mathf.Abs(totalYRotation) >= 360)
        {
            // Determine the number of complete rotations
            int rotations = Mathf.FloorToInt(Mathf.Abs(totalYRotation) / 360);
            completeRotations += rotations;

            // Debug log to show the rotation count
            Debug.Log("Complete Rotations on Y-Axis: " + completeRotations.ToString());
            Debug.Log(" totalYRotation:" + totalYRotation.ToString());
            deltaTime = Time.time - deltaTime;
            Debug.Log("Time.time:" + Time.time);
            Debug.Log("deltaTime:" + deltaTime);

            if (recalcYear)
            {
                timeController.setYear(25800 - 241 - (int)Mathf.Floor(((zodiacTransform.eulerAngles.y) * timeController.precessionYearsPerDegree)));
                recalcYear = false;
                sASUI.blurYear = false; 
            }
            else
            {
                // Notify the time controller that another year has passed
                timeController.newYear();
            }

            // Adjust totalYRotation to account for the complete rotations
            totalYRotation = totalYRotation % 360;
        }
        else
        {
            if (recalcYear)
            {
                timeController.setYear(25800 - 241 - (int)Mathf.Floor(((zodiacTransform.eulerAngles.y) * timeController.precessionYearsPerDegree)));
                recalcYear = false;
                sASUI.blurYear = false;
            }
        }

        // Update lastYAngle for the next frame
        lastYAngle = transform.eulerAngles.y;
    }
}