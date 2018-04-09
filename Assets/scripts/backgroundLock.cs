using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class backgroundLock : MonoBehaviour {
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
        if (rd == null) return;

        transform.localScale = Vector3(1, 1, 1);

        var width = rd.bounds.size.x;
        var height = rd.bounds.size.y;

        var worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale.x = worldScreenWidth / width;
        //transform.localScale.y = worldScreenHeight / height;
        
    }
}
*/