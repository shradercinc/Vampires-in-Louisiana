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
    public string ThisName;

    public string sceneSend; //scene being told to the dialogue display.
    public float socialStat;
    public float hasTalked = 0; //Determins if the NPC has talked already (0 not talked, 1 talking, >1 has talked)

    public GameObject alignmentManager;
    public EndAlignment FinalAlign;

    private void Start()
    {
        FinalAlign = GameObject.FindGameObjectWithTag("FinalAlignment").GetComponent<EndAlignment>();
        alignmentManager = GameObject.FindGameObjectWithTag("Aligner"); //functions properly now, collects "bite"
        socialStat = alignmentManager.GetComponent<AilmentManager>().alignment; 
    }


    public void Update()
    {
        socialStat = alignmentManager.GetComponent<AilmentManager>().alignment;
        if (hasTalked == 1)
        {
            FinalAlign.GlobalAlignment += socialStat;
            print(FinalAlign.GlobalAlignment);
            hasTalked++;
        }


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
