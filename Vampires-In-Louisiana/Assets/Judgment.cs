using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Judgment : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float Distance;
    private Vector3 dir;
    private Transform Pos;
    private bool inrange = false;
    public GameObject TextPlatform;
    private string nextScene;
    private EndAlignment Final;

    // Start is called before the first frame update
    void Start()
    {
        Pos = GetComponent<Transform>();
        TextPlatform = GameObject.FindGameObjectWithTag("Alert");
        Player = GameObject.FindGameObjectWithTag("Player");
        Final = GameObject.FindGameObjectWithTag("FinalAlignment").GetComponent<EndAlignment>();
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
                    print("End Last Day");
                    if (Final.GlobalAlignment >= 7)
                    {
                        SceneManager.LoadScene("END POS");
                    }
                    if (Final.GlobalAlignment < 7 && Final.GlobalAlignment >= 0)
                    {
                        SceneManager.LoadScene("END NUE");
                    }
                    if (Final.GlobalAlignment < 0)
                    {
                        SceneManager.LoadScene("END NEG");
                    }
                }
            }
        }
        else if (inrange == true)
        {
            inrange = false;
            TextPlatform.GetComponent<TMP_Text>().text = "";
        }
    }
}
