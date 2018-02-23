using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStatus : MonoBehaviour {
    public float health = 10;
    public int healthMax = 10;
    public int stamina = 10;
    public float heavyAttackValue = 4f;
    public float runValue = 2f;

    public Rigidbody2D rb;
    public playerController pc;

    public float addHealth(float boost) {
        health += boost;

        if (health > healthMax)
        {
            health = healthMax;
        }
        return (health);
    }

    //public 
}
