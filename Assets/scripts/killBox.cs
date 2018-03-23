using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour {
    public characterStatus status;
    public GameObject characterStat;

	// Use this for initialization
	void Update () {
        //characterStat = GameObject.Find("Player");
        //status = characterStat.GetComponent("characterStatus") as characterStatus;
    }

    void OnTriggerEnter(Collider other)
    {
        print("Test");
        status.Die();
    }
}
