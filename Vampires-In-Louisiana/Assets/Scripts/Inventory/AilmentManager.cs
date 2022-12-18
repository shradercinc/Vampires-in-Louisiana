using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AilmentManager : MonoBehaviour
{
    public string problem;
    public float alignment = 0;
    public GameObject Head;
    public GameObject ArmR;
    public GameObject Torso;
    public GameObject Legs;
    public string[] Best;
    public string[] Good;
    public string[] Bad;
    public string[] Worst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alignment = 0;
        var headItem = Head.GetComponent<Bodypart>().itemString + "/Head";
        var armItem = ArmR.GetComponent<Bodypart>().itemString + "/Arm";
        var torsoItem = ArmR.GetComponent<Bodypart>().itemString + "/Torso";
        var legItem = ArmR.GetComponent<Bodypart>().itemString + "/Leg";
        print(headItem);

        foreach (var x in Best)
        {
            if (headItem == x || armItem == x || torsoItem == x || legItem == x)
            {
                alignment += 2;
            }
        }
        foreach (var x in Good)
        {
            if (headItem == x || armItem == x || torsoItem == x || legItem == x)
            {
                alignment += 1;
            }
        }
        foreach (var x in Bad)
        {
            if (headItem == x || armItem == x || torsoItem == x || legItem == x)
            {
                alignment -= 1;
            }
        }
        foreach (var x in Worst)
        {
            if (headItem == x || armItem == x || torsoItem == x || legItem == x)
            {
                alignment -= 2;
            }
        }

    }
}
