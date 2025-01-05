using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private float zoomLevel;
    private float zoomMultiplier = 4f;
    private float minZoomLevel = 2f;
    private float maxZoomLevel = 8f;
    private float zoomVelocity = 0f;
    private float smoothTime = 0.25f;

    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        zoomLevel = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoomLevel -= scroll * zoomMultiplier;
        zoomLevel = Mathf.Clamp(zoomLevel, minZoomLevel, maxZoomLevel);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoomLevel, ref zoomVelocity, smoothTime);
        cam.GetComponent<Pan>().setSensMultiplier(zoomLevel);
    }
}
