using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float WalkSpeed;
    private float ZInput = 0;
    private float XInput = 0;

    private Transform pos;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity += transform.forward * XInput * WalkSpeed;
        rb.velocity += transform.right * ZInput * WalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ZInput = Input.GetAxis("Horizontal");
        XInput = Input.GetAxis("Vertical");
    }
}
