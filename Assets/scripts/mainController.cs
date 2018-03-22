using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainController : MonoBehaviour {
    float walkSpeed = 10;                       //walk speed
    public float jumpSpeed = 8;                 //how fast character jump
    public float runSpeed;                      //run speed
    public Rigidbody2D rb;                      //initialized the rigbody of the character 
    public Vector2 vectH = new Vector2(1, 0);   //direction for horizontal movement
    public Vector2 vectV = new Vector2(0, 1);   //direction of vertical movemnet
    public bool isJumping = false;              //check for jumping or not
    float horizontal;                           //input for walking
    float vertical;                             //input for jumping
    float jumpH;                                //horizontal movement for jump

	// Use this for initialization
	void Start () {    
        jumpH = walkSpeed / 2;
	}
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal > 0) {
            transform.Translate(vectH * walkSpeed * Time.deltaTime);
        }
        else if (horizontal < 0){
            transform.Translate(vectH * -1 * walkSpeed * Time.deltaTime);
        }

        //jump cojntroll
        if (rb.velocity.y == 0){
            if (vertical > 0) {
                rb.AddForce(vectV * jumpSpeed, ForceMode2D.Impulse);
                rb.AddForce(vectH * jumpH * Mathf.Round(horizontal), ForceMode2D.Impulse);
                isJumping = true;
            }
            else isJumping = false;
        }

	}
}
