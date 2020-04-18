using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask WhatisEnemy;
    public Animator anim;
    public int damage;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 1;
    


    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (timeBtwAttack <= 0)
        {
            Attack();
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode. O))
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                FindObjectOfType<AudioManager>().Play("Attack1");
                anim.SetBool("At1", true);
                Debug.Log("At1");
                Damage();
               
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            FindObjectOfType<AudioManager>().Play("Attack2");


        }
        
    }
    public void Damage()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, WhatisEnemy);
        foreach (Collider2D enemy in enemiesToDamage)
        {
            if(enemy.gameObject.tag == "MiniRat")
            {
                FindObjectOfType<AudioManager>().Play("Hit");
                enemy.GetComponent<ratcontrols>().TakeDamage(damage);
                FindObjectOfType<AudioManager>().Play("Hit");
            }
            else if (enemy.gameObject.tag == "SptRat")
            {
                FindObjectOfType<AudioManager>().Play("Hit");
                enemy.GetComponent<SpitRatcontrols>().TakeDamage(damage);
                FindObjectOfType<AudioManager>().Play("Hit");
            }
            
           
          
        }
        timeBtwAttack = startTimeBtwAttack;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    
}
