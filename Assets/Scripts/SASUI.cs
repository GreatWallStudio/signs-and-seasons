using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SASUI : MonoBehaviour
{
    [SerializeField] TMP_Text displayDaysEllapsed;
    [SerializeField] TMP_Text displayYearsEllapsed;
    [SerializeField] TMP_Text displayAgesEllapsed;
    [SerializeField] TMP_Text displayHMSEllapsed;
    [SerializeField] TMP_Text displayAgeName;
    [SerializeField] int daysEllapsedValue;
    [SerializeField] GameObject menu; 
    [SerializeField] GameObject toggleMenuOn; 
    [SerializeField] PanelManager panelManager;

    [SerializeField] GameObject upperButtonScrollLimit;  
    [SerializeField] GameObject lowerButtonScrollLimit;  
    [SerializeField] GameObject bottomButton;  
    [SerializeField] GameObject topButton;  
    [SerializeField] GameObject movingMenu;  
    [SerializeField] float movingUp;  
    [SerializeField] float movingDown;
    public bool blurYear; 

    void Start()
    {
        //initialize the days display
        displayDaysEllapsed.SetText(daysEllapsedValue.ToString());
        
        //start with the menu off toggle hidden
        toggleMenuOn.SetActive(false);

        movingUp = 0;
        movingDown = 0;
        blurYear = false; 

    }

    public void updateAgeDisplay(int CountOfAges)
    {
        displayAgesEllapsed.SetText("Ages: " + CountOfAges.ToString());
    }
    public void updateYearsDisplay(int CountOfYears)
    {
         if (blurYear)
        {
            displayYearsEllapsed.SetText("Years: -");
        }
        else
        {
            displayYearsEllapsed.SetText("Years: " + CountOfYears.ToString());
        }
    }
    public void updateDaysDisplay(int CountOfDays)
    {

            displayDaysEllapsed.SetText("Days: " + CountOfDays.ToString());

    }
    public void updateHoursDisplay(string hms)
    {
        displayHMSEllapsed.SetText($"Hour: {hms}");
    }
    public void updateAgeNameDisplay(string age) {
        displayAgeName.SetText($"Age of {age}");
            }
    public void moveMenuUp(float speed)
    {
        movingUp = speed; 

    }
    public void stopMoveMenuUp()
    {
        movingUp = 0;
    }
    public void moveMenuDown(float speed)
    {
        movingDown = speed; 

    }
    public void stopMoveMenuDown()
    {
        movingDown = 0;
    }

    private void LateUpdate()
    {
//        Debug.Log($"bottomButton.transform.position.y = {bottomButton.transform.position.y} & " +
//            $"lowerButtonScrollLimit.transform.position.y = {lowerButtonScrollLimit.transform.position.y- 70}"); 

        if (movingUp != 0 && bottomButton.transform.position.y < lowerButtonScrollLimit.transform.position.y + 40  )
        {
            movingMenu.transform.SetPositionAndRotation(new Vector3(movingMenu.transform.position.x,
                                                movingMenu.transform.position.y + movingUp,
                                                movingMenu.transform.position.z),
                                                movingMenu.transform.rotation);
        }
        if (movingDown != 0 && topButton.transform.position.y > upperButtonScrollLimit.transform.position.y - 40)
        {
            movingMenu.transform.SetPositionAndRotation(new Vector3(movingMenu.transform.position.x,
                                                movingMenu.transform.position.y - movingDown,
                                                movingMenu.transform.position.z),
                                                movingMenu.transform.rotation);
        }
    }
}