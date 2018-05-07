using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainController : MonoBehaviour {
    float walkSpeed = 10;                       //walk speed
    public float jumpSpeed = 8;                 //how fast character jump
    public float runSpeed;                      //run speed
    public Rigidbody2D rb;                      //initialized the rigbody of the character 
    public characterStatus staus;
    //public enemyStatus estatus;               //status of enemy, need AI for this
    public Animator anim;
    public Vector2 vectH = new Vector2(1, 0);   //direction for horizontal movement
    public Vector2 vectV = new Vector2(0, 1);   //direction of vertical movemnet
    public bool isControllable = true;
    float attackDirection;
    float horizontal;                           //input for walking
    float vertical;                             //input for jumping
    float sudoku;                               //kill button
    float sprint;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        runSpeed = walkSpeed * 1.2f;
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
            attackDirection = Input.GetAxis("Attack");

            if (sudoku > 0){staus.Die();}

            if (Input.GetMouseButtonDown(0)){
                attackDirection = 1f;
                attack();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                attackDirection = -1f;
                attack();
            } else
            {
                attackDirection = 0f;
            }
          
            

            if (sprint > 0){
                if (horizontal > 0){
                    transform.Translate(vectH * runSpeed * Time.deltaTime);
                }
                else if (horizontal < 0){
                    transform.Translate(vectH * -1 * runSpeed * Time.deltaTime);
                }
            }

            if (horizontal > 0){ //Mr. Game & Watch walk
                anim.SetBool("reverseRun", true);
                transform.Translate(vectH * walkSpeed * Time.deltaTime);
            }
            else if (horizontal < 0){
                anim.SetBool("run", true);
                transform.Translate(vectH * -1 * walkSpeed * Time.deltaTime);
            }
            else if (horizontal == 0)
            {
                anim.SetBool("reverseRun", false);
                anim.SetBool("run", false);
            }

            //jump cojntroll
            if (rb.velocity.y == 0){
                if (vertical > 0){
                    rb.AddForce(vectV * jumpSpeed, ForceMode2D.Impulse);
                }
            }

        }
    }

    public void attack()
    {
        if (attackDirection > 0){
            anim.SetTrigger("attack");
        }
        else if (attackDirection < 0)
        {
            anim.SetTrigger("attack2");
        }
    }

    public void OnTriggerEnter2D(Collider2D enemy)
    {
        float damage = 2f;
        if (attackDirection != 0)
        {
            if (enemy.gameObject.tag == "enemy")
            {
                //eStatus.eTakeHealth(damage);  //for when enemy status is put in
            }
        }
    }
}
