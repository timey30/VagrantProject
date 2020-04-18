using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
   

  
    private GameObject target;
    

    public int damage = 1;
    private bool inRange;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
 
    public float attackRange;
    public LayerMask player;
    public Animator anim;
    private float distance;
   
    public Transform playerPos;



    void Start()
    {
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        anim.GetComponent<Animator>();
    }
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            distance = Vector2.Distance(transform.position, playerPos.position);
            if (attackRange >= distance)
            {
                inRange = true;

            }
            else
            {
                inRange = false;
            }

            if (inRange)
            {

                anim.SetTrigger("isAttacking");
                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, player);
                foreach (Collider2D players in playerToDamage)
                {
                    players.GetComponent<Heart>().TakeDamage(-damage);
                    
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                anim.SetBool("isFollowing", true);
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
     
    }





}
