using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    //list structure for inventory, DONT TOUCH HIGHLY UNSTABLE
    public class Inventory
    {
        public string InName;
        public Sprite InIcon;


        public Inventory(string newName, Sprite newIcon)
        {
            InName = newName;
            InIcon = newIcon;
        }
    }

    //prefab icon
    public GameObject Icon;
    //list containing item information 
    public List<Inventory> Inv = new List<Inventory>();
    //Connected to the start position of the list, not written in
    private TMP_Text Tex;
    //Checks if the visible list is enabled or disabled
    public bool checking = false;
    //semi redundant? OLd variable that adjusts icon size
    public float Iheight = 0;
    //used campus
    public Canvas Can;
    //iteration variable for creating visible inventory list
    public int LP = 0;
    //Checks to see if the list is made
    private bool ListMade = false;
    //allows Icons to reload the list when used
    public bool RedoList = false;


    // Start is called before the first frame update
    void Start()
    {
        Tex = GameObject.FindGameObjectWithTag("Inven").GetComponent<TMP_Text>();
        Iheight = Tex.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            //flips variable disabling or enabling the list
            checking = !checking;
            Tex.text = "";
            LP = 0;


            if (Inv.Count == 0)
            {
                Tex.text = "Inventory Empty";
            }
        }
        if (checking == true)
        {
            //redundant to make sure no duplicate lists are made
            if (ListMade == false)
            {
                //iterates through list creating icon prefabs and passing important variables to them in ICON SCRIPT
                foreach (Inventory x in Inv)
                {
                    var ick = Object.Instantiate(Icon, new Vector3(Tex.transform.position.x, Tex.transform.position.y - (2.3f * Iheight) * LP, Tex.transform.position.z), Tex.transform.rotation, Tex.transform);
                    ick.GetComponent<Icon>().Txr = x.InIcon;
                    ick.GetComponentInChildren<TMP_Text>().text = x.InName;
                    ick.GetComponent<Icon>().itemName = x.InName;
                    ick.GetComponent<Icon>().InventoryManager = this.gameObject;
                    ick.GetComponent<Icon>().listNo = LP;
                    //print(x.InName + " with " + x.InIcon);
                    LP++;
                }
                ListMade = true;
            }

            Tex.enabled = true;
        }
        else
        {
            ListMade = false;
            Tex.enabled = false;
        }

        //Identical to list iteration and creation above, used when the list is reset when an item is deleted.
        if (RedoList == true)
        {
            LP = 0;
            print("Redolist");
            foreach (Inventory x in Inv)
            {
                var ick = Object.Instantiate(Icon, new Vector3(Tex.transform.position.x, Tex.transform.position.y - (2.3f * Iheight) * LP, Tex.transform.position.z), Tex.transform.rotation, Tex.transform);
                ick.GetComponent<Icon>().Txr = x.InIcon;
                ick.GetComponentInChildren<TMP_Text>().text = x.InName;
                ick.GetComponent<Icon>().itemName = x.InName;
                ick.GetComponent<Icon>().InventoryManager = this.gameObject;
                ick.GetComponent<Icon>().listNo = LP;
                //print(x.InName + " with " + x.InIcon);
                LP++;
            }
            RedoList = false;   
        }
    }
}
