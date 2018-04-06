using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundLock : MonoBehaviour {
    public float scale;
    public float inverseScale;
    public float imgWidth = 1080f;
    public Renderer rd;
    public Camera camera;

    void Awake()
    {
        camera = GetComponentInParent<Camera>();
        rd = GetComponent<Renderer>();
    }

    void Start()
    {
        scale = camera.pixelWidth / imgWidth;        
        inverseScale = 1 / scale;

        transform.localScale = new Vector3(inverseScale, inverseScale, 1);

        print("the scale: " + scale);
        print("the camera: " + camera.pixelHeight);
        print("the image: " + rd.bounds.size);
        
    }
}
