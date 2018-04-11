using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seigeController : MonoBehaviour {
    public float endPos = 30f;
    public float speed = 8f;
    public Vector3 direction = new Vector3(1, 0, 0);
    public float currentPos;
    public GameObject player;
    public Collider2D playerCollider;

	// Use this for initialization
	void Start () {
        currentPos = transform.position.x;
        player = GameObject.Find("Player");
        //Physics2D.IgnoreCollision
	}
	
	// Update is called once per frame
	void Update () {
        currentPos = transform.position.x;

        print("test");
        if (currentPos < endPos)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            currentPos = transform.position.x;
            
        }
	}
}
