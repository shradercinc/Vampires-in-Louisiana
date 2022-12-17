using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    //this script uses the CSVReader plugin. 
    //this is placed on an empty.

    List<Dictionary<string, object>> mydata;
    public string day; //which sheet to access

    public TMP_Text textName; //display boxes
    public TMP_Text textLine;

    public string sceneKey; //name of scene -- same as the key on the google sheet.
    public string introKey; //for intro/set in stone story scenes

    public int offset = -1;
    public List<string> currentDialogue = new List<string>();
    public List<string> currentSpeaker = new List<string>();

    public bool near; //scenes are only set when they are near a specific target
    public string currentText;
    public int storyState = 0;
    bool storyTime = true;
    public Image blackScreen;
    public Image dialogueBox;

    private void Start()
    {
        textLine.enabled = true;
        textName.enabled = true;
        mydata = CSVReader.Read(day);
        Greet();
    }
    


    //-------------------------------------------
    //for NPC proximity dialogue popup
    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == "NPC")
        {
            near = true;
            sceneKey = target.gameObject.GetComponent<npcCall>().sceneSend;            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        near = false;
    }
    //---------------------------------------------

    

    void Greet()
    {
        switch (storyState)
        {
            //intro text--------------------
                case 0:
                dialogueBox.enabled = false;
                blackScreen.enabled = true;
                introKey = "Intro";
                storyTime = true;
                fetchDialogue(introKey);
                break;

            case 1:
                introKey = "WakeUp";
                fetchDialogue(introKey);
                break;

            case 2:
                introKey = "AilHint";
                fetchDialogue(introKey);
                break;
            //--------------------

            //night time text
            case 5:
                blackScreen.enabled = true;
                storyTime = true;
                offset = 0;
                currentSpeaker.Clear();
                currentDialogue.Clear();
                textLine.enabled = true;
                textName.enabled = true;
                introKey = "NightTime";
                fetchDialogue(introKey);
                break;

            //npc interaction during day
            default:
                blackScreen.enabled = false;
                storyTime = false;
                currentSpeaker.Clear();
                currentDialogue.Clear();
                offset = -1;
                textLine.enabled = false;
                textName.enabled = false;
                introKey = null;
                break;

        }
    }


    void Update()
    {
        

        //for story prompt----------------------------
        if (storyTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                offset++;

                if (offset == currentDialogue.Count)
                {
                    currentSpeaker.Clear();
                    currentDialogue.Clear();
                   // textLine.enabled = false;
                   // textName.enabled = false;
                    offset = 0;
                    introKey = null;
                    storyState++;
                    Greet();
                }
            }
        } 
        else
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentDialogue.Count == 0)
                {
                    fetchDialogue(sceneKey);
                    dialogueBox.enabled = true;
                }

                offset++;

                if (offset == currentDialogue.Count)
                {
                    currentSpeaker.Clear();
                    currentDialogue.Clear();
                    offset = -1;
                    textLine.enabled = false;
                    textName.enabled = false;
                    dialogueBox.enabled = false;
                    sceneKey = null;
                }
            }
        } 
        else
        if (Input.GetKey(KeyCode.B))   //TESTING KEY FOR GOING TO BED ****************************
        {
            storyState = 5;
            Greet();
        }

        textLine.text = currentDialogue[offset];
        textName.text = currentSpeaker[offset];

    }

    public void fetchDialogue(string keyType)
    {

        string key;
        textName.enabled = true;
        textLine.enabled = true;


        for (int i = 0; i < mydata.Count; i++) //runs down entire list 
        {
            key = mydata[i]["Key"].ToString(); //converts list into readable string

            if (key == keyType) //if the list runs into the scene key string on sheet...
            {
                //add i with matching key to the current dialogue list 
                currentDialogue.Add(mydata[i]["Line"].ToString());
                currentSpeaker.Add(mydata[i]["Speaking Character"].ToString());
            }

        }

    }


}
