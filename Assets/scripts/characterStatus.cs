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
    public Vector2 initialPos;                  //the starting position of character

    void start(){
        initialPos = rb.transform.position;
    }


    public void RunDrain(){
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
        int wait = 1;
        print("dead");

        pc.isControllable = false;
        Delay(wait);

        transform.position = initialPos;
        
    }

    private IEnumerator Delay(int delay) {
        yield return new WaitForSeconds(delay);
    }
}
