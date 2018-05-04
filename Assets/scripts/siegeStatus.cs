using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siegeStatus : MonoBehaviour
{
    public float siegeHealth = 10f;                  //the max health of character
    public int sHealthMax = 10;                  //variable used to reset health

    public Rigidbody2D sRb;                      //the rigbody for the character
    public mainController sPc;                   // the main controller that handles movement
    public Animator siegeAnim;

    void Awake(){
    }

    public float sAddHealth(float boost)
    {      //resets the health of player
        siegeHealth += boost;

        if (siegeHealth > sHealthMax)
        {
            siegeHealth = sHealthMax;
        }
        return (siegeHealth);
    }

    public void sDie()
    {
        print("dead");

        sPc.isControllable = false;
        sReset();
        Invoke("controll", .05f);
    }

    private void sReset()
    {
        sRb.velocity = Vector2.zero;                 //rests the velocity to 0
        sRb.angularVelocity = 0;                     //rests angular velocity to zero
        //transform.position = initialPos;            //goes to the initial position
        transform.rotation = Quaternion.identity;   //resets the rotation of character... just incase

        sAddHealth(sHealthMax);
    }
}
