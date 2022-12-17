using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableGrab : MonoBehaviour
{
    public GameObject TextPlatform;
    public GameObject Player;
    public GameObject Message;
    private bool isclose;
    private Transform Pos;
    public string Name; 
    public Sprite Img;
    public float Dist;
    private Vector3 dir;
    private bool inrange = false;

    // Start is called before the first frame update
    void Start()
    {
        TextPlatform = GameObject.FindGameObjectWithTag("Alert");
        Pos = GetComponent<Transform>();
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        dir = Player.transform.position - Pos.position;

        if (Physics.Raycast(Pos.position, dir, out RaycastHit struck, Dist))
        {
            if (struck.transform.tag == "Player")
            {
                Debug.DrawRay(Pos.position, dir, Color.red);
                TextPlatform.GetComponent<TMP_Text>().text = Name;
                inrange = true;
            }        //print("In range");
        }
        else if (inrange == true)
        {
            TextPlatform.GetComponent<TMP_Text>().text = "";
            inrange = false;
        }
        

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(Pos.position, dir, out RaycastHit hit, Dist))
        {
            if (hit.transform.tag == "Player")
            {
                print("Hit!");
                Player.GetComponent<InventoryManager>().Inv.Add(new InventoryManager.Inventory(Name, Img));
                var IconGet = Object.Instantiate(Message, TextPlatform.transform.position, TextPlatform.transform.rotation, TextPlatform.transform);
                IconGet.GetComponent<TMP_Text>().text = "Scavanged " + Name;
                TextPlatform.GetComponent<TMP_Text>().text = "";
                Destroy(this.gameObject);
            }
        }
    }
}
