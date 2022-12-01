using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataLoader : MonoBehaviour
{
    //this script uses the CSVReader plugin. 
    //this is placed on an empty.

    List<Dictionary<string, object>> mydata;
    public string day; //which sheet to access

    public TMP_Text textName; //display boxes
    public TMP_Text textLine;

    public string sceneKey; //name of scene -- same as the key on the google sheet.

    public int offset = -1;
    public List<string> currentDialogue = new List<string>();
    public List<string> currentSpeaker = new List<string>();

    public bool near; //scenes are only set when they are near a specific target


    private void Start()
    {
        textLine.enabled = false;
        textName.enabled = false;
        mydata = CSVReader.Read(day);

    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == "NPC")
        {
            Debug.Log("woohoo!");
            near = true;
            sceneKey = target.gameObject.GetComponent<npcCall>().sceneSend;            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        near = false;
        
    }



    void Update()
    {
        //Debug.Log(sceneKey);

        if (near)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentDialogue.Count == 0)
                {
                    fetchDialogue();
                }

                offset++;

                if (offset == currentDialogue.Count)
                {
                    currentSpeaker.Clear();
                    currentDialogue.Clear();
                    offset = -1;
                    textLine.enabled = false;
                    textName.enabled = false;
                    sceneKey = null;
                }
            }
        }

        textLine.text = currentDialogue[offset];
        textName.text = currentSpeaker[offset];

    }

    void fetchDialogue()
    {
        Debug.Log("fetching!");

        string key;
        textName.enabled = true;
        textLine.enabled = true;


        for (int i = 0; i < mydata.Count; i++) //runs down entire list 
        {
            key = mydata[i]["Key"].ToString(); //converts list into readable string

            if (key == sceneKey) //if the list runs into the scene key string on sheet...
            {
                //add i with matching key to the current dialogue list 
                currentDialogue.Add(mydata[i]["Line"].ToString());
                currentSpeaker.Add(mydata[i]["Speaking Character"].ToString());
            }

        }

    }


}
