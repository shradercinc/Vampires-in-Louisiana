using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    private bool checking = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            checking = !checking;
        }
        if (checking == true)
        {
            foreach (Inventory x in Inv)
            {
                print(x.InName + " with " + x.InIcon);
            }
            checking = false;
        }
    }
}
