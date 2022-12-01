using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDialogue : MonoBehaviour
{
    public string sceneKeyCall = null;
    public bool near; //scenes are only set when they are near a specific target

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            near = true;
        } else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            near = false;
            sceneKeyCall = null;
        }



        if (near)
        {

            //accepts a scenekey string from the NPC in the trigger zone
            //sets sceneKeyCall to this string, sends it to the display box

            //----------------------------
            //just examples below

            if (Input.GetKeyDown(KeyCode.P))
            {
                sceneKeyCall = "MAMA_MPR";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                sceneKeyCall = "MAMA_PR";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        near = true;
    }

    private void OnTriggerExit(Collider other)
    {
        near = false;
        sceneKeyCall = null;
    }



}
