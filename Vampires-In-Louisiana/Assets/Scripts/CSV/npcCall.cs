using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcCall : MonoBehaviour
{
    //this goes on the npc! 
    //set each of these to the unique characters name/response key

    public string MPR;
    public string PR;
    public string MR;
    public string NR;
    public string MNR;

    public string sceneSend; //scene being told to the dialogue display.
    public float socialStat;

    public GameObject alignmentManager;

    private void Start()
    {
        alignmentManager = GameObject.FindGameObjectWithTag("Aligner");
        socialStat = alignmentManager.GetComponent<AilmentManager>().alignment; //TEST STAT PLEASE CHANGE LATER to get component on stat machine
    }


    public void Update()
    {
        socialStat = alignmentManager.GetComponent<AilmentManager>().alignment;
        //MPR = 2
        if (socialStat >= 2)
        {
            sceneSend = MPR;

        } else

        //PR = 1
        if (socialStat == 1)
        {
            sceneSend = PR;
        }

        //MR = 0
        else
        if (socialStat == 0)
        {
            sceneSend = MR;
        }

        //NR = -1
        else
        if (socialStat == -1)
        {
            sceneSend = NR;
        }

        //MNR = -2
        else
        if (socialStat <= -2)
        {
            sceneSend = MNR;
        }

    }
}
