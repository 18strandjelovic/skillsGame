using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
    public Transform player;
    public float marginX = 3f;
    public float marginY = 1f;
    public float smoothX = 8f;
    public float smoothY = 8f;
    public float increaseHeight = .4f;
    public Vector2 minXY;
    public Vector2 maxXY;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    private bool CheckXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - player.position.x) > marginX;
    }

    private bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.transform.position.y) > marginY;
    }

    private void tracking() {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin()){
            targetX = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothX * Time.deltaTime);
        }
        /*
        if (CheckYMargin()){
            targetY = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothY * Time.deltaTime);
        }
        */ 
        targetX = Mathf.Clamp(targetX, minXY.x, maxXY.x);
        targetY = Mathf.Clamp(targetY, minXY.y, maxXY.y);

        transform.position = new Vector3(targetX, targetY /*+ increaseHeight*/, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        tracking();
	}
}
