using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
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

    public GameObject Icon;
    public List<Inventory> Inv = new List<Inventory>();
    private TMP_Text Tex;
    public bool checking = false;
    public float Iheight = 0;
    public Canvas Can;
    public int LP = 0;
    private bool ListMade = false;


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
            checking = !checking;
            Tex.text = "";
            LP = 0;

            /*
            if (Tex.text == "")
            {
                Tex.text = "Inventory Empty";
            } */
        }
        if (checking == true)
        {
            if (ListMade == false)
            {

                foreach (Inventory x in Inv)
                {
                    var ick = Object.Instantiate(Icon, new Vector3(Tex.transform.position.x, Tex.transform.position.y - (2.3f * Iheight) * LP, Tex.transform.position.z), Tex.transform.rotation, Tex.transform);
                    ick.GetComponent<Icon>().Txr = x.InIcon;
                    ick.GetComponentInChildren<TMP_Text>().text = x.InName;
                    ick.GetComponent<Icon>().InventoryManager = this.gameObject;
                    ick.GetComponent<Icon>().listNo = LP;
                    print(x.InName + " with " + x.InIcon);
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
    }
}
