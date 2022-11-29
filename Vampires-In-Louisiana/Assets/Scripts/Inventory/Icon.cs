using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public GameObject pl;
    private Image img;
    public Sprite Txr;
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        img = GetComponent<Image>();
        img.sprite = Txr;
    }

    // Update is called once per frame
    void Update()
    {
        img.enabled = pl.GetComponent<InventoryManager>().checking;
        if (Input.GetKeyDown(KeyCode.I))
        {
            Destroy(this.gameObject);
        }    
    }
}
