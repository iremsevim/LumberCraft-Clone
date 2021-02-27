using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    public Canvas buildcanvas;
    public void Update()
    {
        TalkingCanvasFaceToCamera();
    }
    private void TalkingCanvasFaceToCamera()
    {
        if (buildcanvas == null) return;
        if (!buildcanvas.gameObject.activeInHierarchy) return;

        Camera camera = Camera.main;
        buildcanvas.transform.LookAt(buildcanvas.transform.position + (camera.transform.rotation * Vector3.back), camera.transform.rotation * Vector3.up);
    }
}
