using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seigeController : MonoBehaviour {
    public float endPos = 30f;
    public float speed = 8f;
    public Vector3 direction = new Vector3(1, 0, 0);
    public float currentPos;
    public GameObject player;
    public bool isControllable = true;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (isControllable == true) { 
            currentPos = transform.position.x;
            Physics2D.IgnoreLayerCollision(8, 9);

            print("test");
            if (currentPos < endPos)
            {
                transform.Translate(direction * speed * Time.deltaTime);
                currentPos = transform.position.x;
            
            }
        }
	}
}
