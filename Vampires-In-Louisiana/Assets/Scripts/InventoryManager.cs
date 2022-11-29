using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public class Inventory
    {
        public string InName;
        public Texture2D InIcon;

        public Inventory(string newName, Texture2D newIcon)
        {
            InName = newName;
            InIcon = newIcon;
        }
    }

    public List<Inventory> Inv = new List<Inventory>();
    private TMP_Text Tex;
    private bool checking = false;
    public float Iheight = 0;
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
            foreach (Inventory x in Inv)
            {
                Tex.text += x.InName + "\n \n";
                print(x.InName + " with " + x.InIcon);
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
