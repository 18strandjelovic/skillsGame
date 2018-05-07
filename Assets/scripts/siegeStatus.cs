using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siegeStatus : MonoBehaviour
{
    public float sHealth = 10f;                  //the max health of character
    public int sHealthMax = 10;                  //variable used to reset health

    public Rigidbody2D sRb;                      //the rigbody for the character
    public mainController sPc;                   // the main controller that handles movement
    public Animator siegeAnim;

    void Awake(){
    }

    public void sTakeHealth(float damage)
    {
        sHealth -= damage;

        if (sHealth <= 0)
        {
            sDie();
        }
    }

    public void sDie()
    {
        print("dead");

        sPc.isControllable = false;
        Invoke("controll", .05f);
    }
}
