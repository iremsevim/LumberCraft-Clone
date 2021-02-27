using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;
    public Vector3 offset;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) return;
        Vector3 pos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position,pos,0.05f);
    }
}
