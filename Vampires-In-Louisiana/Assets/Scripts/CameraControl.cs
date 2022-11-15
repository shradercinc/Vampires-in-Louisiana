using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform pos;
    public Transform plPos;
    public float YDif = 1.25f;
    public float ZDif = -6f;
    public float Focus = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        pos.position = Vector3.Lerp(pos.transform.position, new Vector3(plPos.transform.position.x, plPos.transform.position.y + YDif, plPos.transform.position.z), Focus);
        pos.localPosition += pos.forward * ZDif;
    }
}
