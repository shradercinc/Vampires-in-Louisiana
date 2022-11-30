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
    public float LP = 0;


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
            foreach (Inventory x in Inv)
            {
                Tex.text += x.InName + "\n \n";
                var ick = Object.Instantiate(Icon, new Vector3(Tex.transform.position.x - 246, Tex.transform.position.y - (2.3f*Iheight) * LP, Tex.transform.position.z), Tex.transform.rotation, Tex.transform) ;
                ick.GetComponent<Icon>().Txr = x.InIcon;
                print(x.InName + " with " + x.InIcon);
                LP++;
            }
        }
        if (checking == true)
        {
            Tex.enabled = true;
        }
        else
        {
            Tex.enabled = false;
        }
    }
}
