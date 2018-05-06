using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour {
    public characterStatus status;
    public GameObject player;
    public siegeStatus siegeMachine;

	// Use this for initialization
    void start()
    {
        siegeMachine = player.GetComponent("siegeStatus") as siegeStatus;
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
            status.Die();
        }
        if (player.gameObject.tag == "siege")
        {
            print("Test");
            siegeMachine.sDie();
        }
    }
}
