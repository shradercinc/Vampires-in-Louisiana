using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NewAlert : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float FadeSpeed;
    private Transform pos;
    private TMP_Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TMP_Text>();
        pos = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        pos.position = new Vector3(pos.position.x, pos.position.y + speed, pos.position.z);
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, Text.color.a - FadeSpeed);
        if (Text.color.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
