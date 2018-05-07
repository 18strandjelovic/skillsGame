using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killBox : MonoBehaviour {
    public characterStatus status;
    public siegeStatus siegeStatus;
    public GameObject player;
    public GameObject siegeMachine;

    void Awake() {
        player = GameObject.Find("running");
        siegeMachine = GameObject.Find("siegeMachine_0");
        status = player.GetComponent("characterStatus") as characterStatus;
        siegeStatus = siegeMachine.GetComponent("siegeStatus") as siegeStatus;
    }

    public IEnumerator OnTriggerEnter2D(Collider2D player)
    {
        StartCoroutine(status.Die());
        if (player.gameObject.tag == "Player")
        {
            status.Die();
        }
        if (player.gameObject.tag == "siege")
        {
            killAll();
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("puzzle level");
        }  
    }

    void killAll()
    {
        status.pc.isControllable = false;
        status.pc.anim.enabled = false;
        siegeStatus.siegeAnim.enabled = false;
    }
}
