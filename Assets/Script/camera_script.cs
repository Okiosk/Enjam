using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering;
using System.Numerics;

public class camera_script : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    private float maxZoom = 8f;
    private float velocity = 0f;
    private float smoothTime = 0.001f;

    private bool zoomEnCour = false;
    private bool dezoomEnCour = false;
    private UnityEngine.Vector3 target;
    private float speed = 0.001f;

    [SerializeField] private Camera cam;

    private void Start()
    {
        zoom = cam.orthographicSize;
    }

    private void Update()
    {
        if (zoomEnCour)
        {
            float scroll = 1;
            zoom -= scroll * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
            gameObject.transform.position = UnityEngine.Vector3.MoveTowards(transform.position, target, speed);
            if (cam.orthographicSize > maxZoom)
            {
                zoomEnCour = false;
            }
        }
    }

    public void doZoom(float x, float y)
    {
        zoomEnCour = true;
        target.x = x;
        target.y = y;
        target.z = -10;

    }
}