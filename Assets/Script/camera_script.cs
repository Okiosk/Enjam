using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering;
using System.Numerics;

public class camera_script : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 0.08f;
    private float minZoom = 2f;
    private float maxZoom = 8f;
    private float velocity = 1f;
    private float smoothTime = 0.01f;

    private bool zoomEnCour = false;
    private bool dezoomEnCour = false;
    private UnityEngine.Vector3 target;
    private int speed = 100;

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
            if (cam.orthographicSize <= 2)
            {
                zoomEnCour = false;
            }
        }
        if (dezoomEnCour)
        {
            float scroll = 1;
            zoom += scroll * zoomMultiplier;
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
        print("zoom");
    }
    public void unzoom()
    {
        dezoomEnCour = true;
        target.x = 0;
        target.y = 0;
        target.z = -10;
        print("dezoom");
    }
}