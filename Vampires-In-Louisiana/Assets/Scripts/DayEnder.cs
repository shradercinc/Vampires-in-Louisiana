using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayEnder : MonoBehaviour
{
    [SerializeField] private GameObject Player; 
    [SerializeField] private float Distance;
    private Vector3 dir;
    private Transform Pos;
    private bool inrange = false;
    public GameObject TextPlatform;
    public string nextScene;

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

            if (hit.transform.tag == "Player")
            {
                Debug.DrawRay(Pos.position, dir, Color.green);
                TextPlatform.GetComponent<TMP_Text>().text = "Press 'E' to end day";
                inrange = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("End Day");
                    SceneManager.LoadScene(nextScene);
                }
            }   
        }   else if (inrange == true)
        {
            inrange = false;
            TextPlatform.GetComponent<TMP_Text>().text = "";
        }
    }
}
