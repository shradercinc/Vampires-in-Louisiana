using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGrab : MonoBehaviour
{
    public GameObject Player;
    private bool isclose;
    private Transform Pos;
    public string Name;
    public Sprite Img;
    public float Dist;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
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
        if(Physics.Raycast(Pos.position, dir, out RaycastHit struck, Dist))
        {
            //print("In range");
            Debug.DrawRay(Pos.position, dir, Color.red);
        }
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(Pos.position, dir, out RaycastHit hit, Dist))
        {
            if (hit.transform.tag == "Player")
            {
                print("Hit!");
                Player.GetComponent<InventoryManager>().Inv.Add(new InventoryManager.Inventory(Name, Img));
            }
        }
    }
}
