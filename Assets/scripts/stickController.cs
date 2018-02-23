using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    float walkSpeed = 10;                       //walk speed
    public Rigidbody2D rb;                      //initialized the rigbody of the character
    public float jumpSpeed = 8;                 //how fast character jumps
    public Vector2 vectH = new Vector2(1, 0);   //direction for horizontal movement
    public Vector2 vectV = new Vector2(0, 1);   //direction of vertical movemnet
    public bool groundCheck = true;             //makes sure that the player is not moving vertically
    public bool isJumping = false;              //check for jumping or not
    public int facingRight = 0;                 //checks for moving in the positive direction, right is 1, left is 2, no direction is 0
    public bool isMoving = false;               //check for if  the character is moving
    float horizontal;                           //input for walking
    float vertical;                             //input for jumping
    float jumpH;                                //horizontal movement for jump

    // Use this for initialization
    void Start()
    {
        jumpH = walkSpeed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (rb.velocity.y != 0)
        {    //check to see if the character is jumping
            groundCheck = false;
        }
        else groundCheck = true;

        if (rb.velocity.x != 0)
        {    //check to see if the character is moving
            isMoving = true;
        }
        else isMoving = false;

        //Horizontal movement controlsd
        if (isJumping == false)
        {
            if (horizontal > 0)
            {
                transform.Translate(vectH * walkSpeed * Time.deltaTime);     //Moves charactor right
                facingRight = 1;                                         //shows that charactor is moving in the positive direction
                isMoving = true;
            }
            else if (horizontal < 0)
            {
                transform.Translate(vectH * -1 * walkSpeed * Time.deltaTime);    //moves charactor left
                facingRight = 2;                                            //shows that charactor is moving in the negative direction
                isMoving = true;
            }
            else if (horizontal == 0)
            {
                facingRight = 0;
                isMoving = false;
            }
        }

        //Jump control
        if (rb.velocity.y == 0)
        {       //makes sure your on the ground
            if (vertical > 0)
            {          //input for jumping
                isJumping = true;
                rb.AddForce(vectV * jumpSpeed, ForceMode2D.Impulse);     //jumps

                switch (facingRight)
                {
                    case 0:
                        isMoving = false;
                        break;
                    case 1:
                        if (isMoving == true)
                        { //put this to encompas whole switch
                            rb.AddForce(vectH * jumpH, ForceMode2D.Impulse);
                        }
                        break;
                    case 2:
                        if (isMoving == true)
                        {
                            rb.AddForce(vectH * -1 * jumpH, ForceMode2D.Impulse);
                        }
                        break;
                }
            }
            else
            {
                isJumping = false;
            }
        }

    }

    public int FacingRight()
    {
        return facingRight;
    }

    public bool IsMoving()
    {
        return vectH.magnitude > 0.5;
    }

    public bool IsJumping()
    {
        return isJumping;
    }
}