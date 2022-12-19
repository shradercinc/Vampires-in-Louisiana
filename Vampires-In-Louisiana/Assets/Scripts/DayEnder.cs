using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayEnder : MonoBehaviour
{
    public AilmentManager Alignment;
    [SerializeField] private GameObject Player; 
    [SerializeField] private float Distance;
    private Vector3 dir;
    private Transform Pos;
    private bool inrange = false;
    public GameObject TextPlatform;
    // Start is called before the first frame update
    void Start()
    {
        Pos = GetComponent<Transform>();
        TextPlatform = GameObject.FindGameObjectWithTag("Alert");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dir = Player.transform.position - Pos.position;
        if (Physics.Raycast(Pos.position, dir, out RaycastHit hit, Distance))
        {
            Debug.DrawRay(Pos.position, dir, Color.red);
            if (hit.transform.tag == "Player")
            {
                TextPlatform.GetComponent<TMP_Text>().text = "Press 'E' to end day";
                inrange = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("End Day");
                }
            }   
        }   else if (inrange == true)
        {
            inrange = false;
            TextPlatform.GetComponent<TMP_Text>().text = "";
        }
    }
}
