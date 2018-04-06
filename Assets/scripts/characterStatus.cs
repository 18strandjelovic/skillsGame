using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStatus : MonoBehaviour {
    public float health = 10f;                  //the max health of character
    public int healthMax = 10;                  //variable used to reset health
    public float stamina = 10f;                 //stainam to be used for running or heavy attack
    public float heavyAttackValue = 4f;         //how much stamina is used for heavy attack
    public float runValue = 2f;                 //stamina used for sprinting

    public Rigidbody2D rb;                      //the rigbody for the character
    public mainController pc;                   // the main controller that handles movement
    public Vector3 initialPos;                  //the starting position of character

    void Awake(){
        initialPos = transform.position;     //sets the initial position
    }


    public void RunDrain(){                    //function for eventual use of sprinting 
        float drain = .2f;
        stamina -= (drain * Time.deltaTime);
    }

    public float addHealth(float boost) {      //resets the health of player
        health += boost;

        if (health > healthMax)
        {
            health = healthMax;
        }
        return (health);
    }

    public void Die() {
        print("dead");

        pc.isControllable = false;
        reset();
        Invoke("controll", .05f);
    }

    private void controll(){
        pc.isControllable = true;
    }

    private void reset() {
        rb.velocity = Vector2.zero;                 //rests the velocity to 0
        rb.angularVelocity = 0;                     //rests angular velocity to zero
        transform.position = initialPos;            //goes to the initial position
        transform.rotation = Quaternion.identity;   //resets the rotation of character... just incase

        addHealth(healthMax);
    }
}
