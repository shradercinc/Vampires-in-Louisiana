using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bodypart : MonoBehaviour
{
    public string[] usable; 
    private bool checking = false;
    private Image img;
    public string itemString = "";

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            img.enabled = !img.enabled;
        }

    }
}
