using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogUI : MonoBehaviour
{
	[SerializeField] string scriptCSVFileName;
	//[SerializeField] TMP_Text dialogPrevious;
	//[SerializeField] TMP_Text dialogCurrent;
	//[SerializeField] TMP_Text dialogOnDeck;
	//[SerializeField] TMP_Text dialogInTheHole;
 //   [SerializeField] GameObject uIElementsToHide; 
 //   [SerializeField] GameObject showIcon; 
 //   [SerializeField] GameObject dialogCanvas;
 //   [SerializeField] AudioClip clip1;
    //private AudioSource soundSource;
    private IEnumerator indexCoroutine;
    private int dialogIndex;
    private bool _autoMode = false;
    private bool _dramaStarted = false;
    private bool _pauseForNPCAudio = false;
    private bool _pauseForAnimation = false;
    private bool _pauseForPlayerAudio = false;
    private bool _pauseForActionVM = false;
    private bool _pauseForActionSW = false;
    private bool _pauseForActionJW = false;
    private bool _pauseForActionCH = false;
    private bool _pauseForActionPR = false;
    private bool _pauseForActionC = false;

    List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

    void Awake()
    {
        //Load in the CSV file
        data = CSVReader.Read(scriptCSVFileName);

        resetDialogIndex();

        ////instantiate audio source for playing dialog
        //soundSource = gameObject.AddComponent<AudioSource>() as AudioSource;
    }

    // Use this for initialization
    void Start()
    {        
        //Load up the dialog into the UI 
        UpdateDialogUI(0); 

        ////Show the UI 
        //uIElementsToHide.SetActive(true);

        ////Show only the eyeball
        //showIcon.SetActive(false);

        Debug.Log($"<color=green>automode In start(). Initializing _autoMode as {_autoMode}, _dramaStarted as {_dramaStarted}, and _pauseForAudio as {_pauseForNPCAudio}. </color>");
    }

    void Update()
	{
        //Keyboard script transport controls
        if (Input.GetKeyDown("e"))
        {
            NextDialog(true); 
        }
        if (Input.GetKeyDown("q"))
        {
            PreviousDialog(); 
        }

        Debug.Log($"<color=green>automode In update() before conditional. _autoMode {_autoMode}, dialogIndex {dialogIndex}," +
            $" _pauseForActionVM {_pauseForActionVM} _pauseForActionSW {_pauseForActionSW} _pauseForActionJW {_pauseForActionJW} " +
            $"_pauseForActionCH {_pauseForActionCH} _pauseForActionPR {_pauseForActionPR} _pauseForActionC {_pauseForActionC} " +
            $"_dramaStarted {_dramaStarted}, and _pauseForAudio {_pauseForNPCAudio}. </color>");

        //Auto Advance when forward button pressed, auto mode is on, a sound isn't starting or already playing
        if (_dramaStarted && _autoMode && !_pauseForActionVM && !_pauseForActionSW && !_pauseForActionJW && !_pauseForActionCH &&
            !_pauseForActionPR && !_pauseForActionC && !_pauseForNPCAudio && !_pauseForPlayerAudio && !_pauseForAnimation) 
            // && !candidate.soundSource.isPlaying)
        {
            // Start function WaitAndIndex as a coroutine.
            indexCoroutine = WaitAndIndex(1f);
            StartCoroutine(indexCoroutine);
        }
    }

    private IEnumerator WaitAndIndex(float waitTime)
    {
            dialogIndex++;
            _pauseForNPCAudio = true;
//         Debug.Log($"<color=green>automode In WaitAndIndex coroutine. set _pauseForAudio = true. </color>");
           yield return new WaitForSeconds(waitTime);
            _pauseForNPCAudio = false;
        //UpdateDialogUI(dialogIndex);
//        Debug.Log($"<color=green>automode In WaitAndIndex coroutine. set _pauseForAudio = false. </color>");

    }
    
    public void turnAutoModeOn()
    {
        _autoMode = true;
        Debug.Log($"<color=green>automode _autoMode set to {_autoMode}. </color>");
    }

    public void turnAutoModeOff()
    {
        _autoMode = false;
        Debug.Log($"<color=green>automode _autoMode set to {_autoMode}. </color>");
    }
   
    public void resetDialogIndex()
    {
        dialogIndex = 0;
    }

    //this is called when the next button is selected in the dialog UI and advance is true
    public void NextDialog(bool advance = false) 
    {
        //_dramaStarted = true;
        //if (!soundSource.isPlaying)
        //{
        //    if (advance && _autoMode)
        //    {
                Debug.Log($"<color=green>automode NextDialog() called _dramaStarted = {_dramaStarted} _autoMode = { _autoMode } _pauseForAudio = {_pauseForNPCAudio}. dialogIndex++ and calling photon event. </color>");
                dialogIndex++;
            //}
            //UpdateDialogUI(dialogIndex);
        //}
    }

    public void PreviousDialog()
    {
        //if (!_autoMode && !soundSource.isPlaying)
        //{
            if (dialogIndex > 0)
            {
                Debug.Log($"<color=green>automode PreviousDialog() called, _autoMode = {_autoMode} _dramaStarted = {_dramaStarted}. dialogIndex-- and calling photon event. </color>");
                dialogIndex--;
            }
            //UpdateDialogUI(dialogIndex);
        //}
    }

    private void UpdateDialogUI(int dialogIndex)
    {
        Debug.Log($"Actions - at the beginning of UpdateDialog(). dialogIndex = {dialogIndex}");
        //at the beginning there should be no previous dialog
        if (dialogIndex > 0)
        {
            //dialogPrevious.text = " " + data[dialogIndex - 1]["line"];
            Debug.Log($" {data[dialogIndex - 1]["line"]}");
        }
        else
        {
            //dialogPrevious.text = "Start of Script";
            Debug.Log("Start of Script");
        }

        //show the current line of dialog
        //dialogCurrent.text = "" + data[dialogIndex]["line"];
        Debug.Log($" {data[dialogIndex]["line"]}"); 

        //audio dialog section
        if (data[dialogIndex]["type"].ToString() == "Dialog")
        { 
            //play file 
            //    venerableMaster.speakDialog(data[dialogIndex]["character"].ToString(), (int)data[dialogIndex]["audio"]);
        }

        Debug.Log($"<color=green>Actions - dialogIndex = {dialogIndex} - right before action section</color>");

        //action / movement section 
        if (data[dialogIndex]["type"].ToString() == "Action")
        {
            //if there's something in their action field then make them move
//                if (!data[dialogIndex]["VMAction"].Equals(null))
            //if (!string.IsNullOrEmpty(data[dialogIndex]["VMAction"].ToString()))
            //{
            //    Debug.Log($"Actions VM");
            //    _pauseForActionVM = true; 
            //    venerableMaster.Move(data[dialogIndex]["VMAction"].ToString(), "Venerable Master"); ;
            //}
        }

        //dialogOnDeck.text = "" + data[dialogIndex + 1]["line"];
        //dialogInTheHole.text = "" + data[dialogIndex + 2]["line"];
    }

    public void ActionComplete(string character)
    {
        //if (character == "Venerable Master")
        //{
        //    _pauseForActionVM = false;
        //    Debug.Log($"Actions after setting _pauseForActionVM = false");
        //}
    }

    public void HideDialogUI()
    {
        //uIElementsToHide.SetActive(false);
        //showIcon.SetActive(true); 
    }

    public void ShowDialogUI()
    {
        //uIElementsToHide.SetActive(true);
        //showIcon.SetActive(false); 
    }
}