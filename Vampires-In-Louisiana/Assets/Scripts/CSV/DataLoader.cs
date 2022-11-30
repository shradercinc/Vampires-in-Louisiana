using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataLoader : MonoBehaviour
{
    //this script uses the CSVReader plugin. 

    List<Dictionary<string, object>> mydata;
    public string day; //which sheet to access

    public string key; //label for the type of dialogue
    public string speakingName; //character display name
    public string line; //spoken line

    public TMP_Text textName; //display boxes
    public TMP_Text textLine;

    void fetchDialogue()
    {
        mydata = CSVReader.Read(day);

        for (int i = 0; i < mydata.Count - i; i++)  //runs down the table 
        {
            Debug.Log("Key: " + mydata[i]["Key"]); // give it a row index, access via column
                                                   //Debug.Log(mydata[i]["Speaking Character"]);
                                                   //Debug.Log(mydata[i]["Line"]);

            speakingName = mydata[i]["Speaking Character"].ToString();
            line = mydata[i]["Line"].ToString();

        }

       

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fetchDialogue();
        }
    }
}
