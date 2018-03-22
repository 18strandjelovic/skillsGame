using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStatus : MonoBehaviour {
    public float health = 10f;
    public int healthMax = 10;
    public float stamina = 10f;
    public float heavyAttackValue = 4f;
    public float runValue = 2f;

    public Rigidbody2D rb;
    public mainController pc;

    public void StaminaDrain(){
        float drain = .2f;

        stamina -= (drain * Time.deltaTime);
    }

    public float addHealth(float boost) {
        health += boost;

        if (health > healthMax)
        {
            health = healthMax;
        }
        return (health);
    }

    public void Die() {
        print("dead");

    }

    //public 
}
