using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour {
    public characterStatus status;
    public GameObject player;

	// Use this for initialization
    void start()
    {
        status = player.GetComponent("characterStatus") as characterStatus;
    }
	void Update () {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            print("Test");
            //Destroy(player);
            status.Die();
        }
    }
}
