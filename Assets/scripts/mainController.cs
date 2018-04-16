﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainController : MonoBehaviour {
    float walkSpeed = 10;                       //walk speed
    public float jumpSpeed = 8;                 //how fast character jump
    public float runSpeed;                      //run speed
    public Rigidbody2D rb;                      //initialized the rigbody of the character 
    public characterStatus staus;
    public Vector2 vectH = new Vector2(1, 0);   //direction for horizontal movement
    public Vector2 vectV = new Vector2(0, 1);   //direction of vertical movemnet
    public bool isControllable = true;
    float horizontal;                           //input for walking
    float vertical;                             //input for jumping
    float jumpH;                                //horizontal movement for jump
    float sudoku;                               //kill button
    float sprint;
    string sceneName;
    float maxWalk;
    float minWalk;

	// Use this for initialization
	void Start () {
        sceneName = SceneManager.GetActiveScene().name;
        jumpH = walkSpeed / 2;
        runSpeed = walkSpeed * 1.2f;

        switch (sceneName)
        {
            case("defenceLevel"):
                maxWalk = 20;
                break;
            case("puzzle level"):
                maxWalk = 100;
                break;
            case("bossLevel"):
                maxWalk = 400;
                break;
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!isControllable)
        {
            Input.ResetInputAxes();
        } else {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            sudoku = Input.GetAxis("Sudoku");
            sprint = Input.GetAxis("sprint");

            if (sudoku > 0){staus.Die();}

            if (sprint > 0){
                if (horizontal > 0){
                    transform.Translate(vectH * runSpeed * Time.deltaTime);
                }
                else if (horizontal < 0){
                    transform.Translate(vectH * -1 * runSpeed * Time.deltaTime);
                }
            }

            if (horizontal > 0){ //Mr. Game & Watch walk
                transform.Translate(vectH * walkSpeed * Time.deltaTime);
            }
            else if (horizontal < 0){
                transform.Translate(vectH * -1 * walkSpeed * Time.deltaTime);
            }

            //jump cojntroll
            if (rb.velocity.y == 0){
                if (vertical > 0){
                    rb.AddForce(vectV * jumpSpeed, ForceMode2D.Impulse);
                    //rb.AddForce(vectH * jumpH * Mathf.Round(horizontal), ForceMode2D.Impulse);
                }
            }

        }
    }
}
