using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering;
using System.Numerics;

public class camera_script : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 0.008f;
    private float minZoom = 2f;
    private float maxZoom = 8f;
    private float velocity = 0f;
    private float smoothTime = 0.01f;

    private bool zoomEnCour = false;
    private bool dezoomEnCour = false;
    private UnityEngine.Vector3 target;
    private int speed = 3;

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
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime * Time.deltaTime);
            gameObject.transform.position = UnityEngine.Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (cam.orthographicSize > maxZoom)
            {
                zoomEnCour = false;
            }
        }
        if (dezoomEnCour)
        {
            Debug.Log("hey");
            float scroll = -1;
            zoom -= scroll * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime * Time.deltaTime);
            gameObject.transform.position = UnityEngine.Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (cam.orthographicSize >= 5)
            {
                dezoomEnCour = false;
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
    public void unzoom()
    {
        dezoomEnCour = true;
        target.x = 0;
        target.y = 0;
        target.z = -10;
    }
}