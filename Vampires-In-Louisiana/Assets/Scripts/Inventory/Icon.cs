using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //passed by inventory manager
    public Sprite Txr;
    public GameObject InventoryManager;
    public int listNo;
    public string itemName;

    public GameObject pl;
    private Transform pos;
    private Image img;
    private Vector3 home;
    private bool isOver = false;
    private bool isDrag = false;
    private bool locked = false;
    private bool touchBody = false;
    private Vector3 bPos;
    public GraphicRaycaster GRay;


    // Start is called before the first frame update
    void Start()
    {

        pos = GetComponent<Transform>();
        pl = GameObject.FindGameObjectWithTag("Player");
        GRay = GameObject.FindGameObjectWithTag("Board").GetComponent<GraphicRaycaster>();
        img = GetComponent<Image>();
        img.sprite = Txr;
        home = pos.position;
        print("Generate" + itemName);
    }

    public void OnPointerEnter(PointerEventData data)
    {
        isOver = true;
    }
    public void OnPointerExit(PointerEventData data)
    {
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        img.enabled = pl.GetComponent<InventoryManager>().checking;
        if (Input.GetKeyDown(KeyCode.I))
        {
            print("delete");
            Destroy(this.transform.GetChild(0).gameObject);
            Destroy(this.gameObject);
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && isOver == true && locked == false)
        {
            pos.position = Input.mousePosition;
            isDrag = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            var eventdata = new PointerEventData(null);
            eventdata.position = Input.mousePosition;
            var resualts = new List<RaycastResult>();
            GRay.Raycast(eventdata, resualts);
            foreach (var resualt in resualts)
            {

                if (resualt.gameObject.CompareTag("Body") && isDrag == true)
                {
                    var usable = false;
                    foreach(var x in resualt.gameObject.GetComponent<Bodypart>().usable)
                    {
                        if (x == itemName)
                        {
                            usable = true;
                            print(x);
                            touchBody = true;
                            bPos = resualt.gameObject.GetComponent<Transform>().position;
                            resualt.gameObject.GetComponent<Image>().sprite = img.sprite;
                            resualt.gameObject.GetComponent<Bodypart>().itemString = itemName;
                            print(itemName + "/" + resualt.gameObject.name);
                            break;
                        }

                    }
                    if (usable == false)
                    {
                        print(itemName + " Not usable on " + resualt.gameObject.name);
                    }
                }
            }
            if (touchBody == true)
            {
                InventoryManager.GetComponent<InventoryManager>().Inv.RemoveAt(listNo);
                Destroy(this.transform.GetChild(0).gameObject);
                Destroy(this.gameObject);
                var ListItems = GameObject.FindGameObjectsWithTag("Icon");
                foreach (var x in ListItems)
                {
                    Destroy(x.transform.GetChild(0).gameObject);
                    Destroy(x.gameObject);
                }
                InventoryManager.GetComponent<InventoryManager>().RedoList = true;
                locked = true;
            } else pos.position = home;
            isDrag = false;
        }

        if (isDrag == true)
        {
            pos.position = Input.mousePosition;
        }

    }
}
