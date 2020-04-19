using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratcontrols : MonoBehaviour
{
    public Animator anim;
    private Transform playerPos;
    private float minDistance = 2f;
    private float range;
    public float speed;
    private float waitTime;
    public float startwaitTime;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // public EnemyHealthBar healthbar;
    private GameObject healthbar;
    public GameObject healthprefab;
    public Transform healthbarlocation;
    public int maxHealth = 3;
    int currentHealth;
    public GameObject bloodEffect;
    private float dazedTime;
    public float startDazedTime;
    private float maxHealthbar = 30.4f;
    private float currentHealthbar;
    private GameObject target;


    public int damage = 1;
    private bool inRange;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;

    public float attackRange;
    public LayerMask player;

    private float distance;

    public Transform playerPoscheck;







    void Start()
    {
       healthbar = Instantiate(healthprefab, healthbarlocation.position, Quaternion.identity) as GameObject;
        healthbar.transform.parent = transform;
        healthbar.GetComponent<EnemyHealthBar>().SetSize(maxHealthbar);
        currentHealthbar = maxHealthbar;
        currentHealth = maxHealth;
        anim.GetComponent<Animator>();
       waitTime = startwaitTime;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

  
    
}

    // Update is called once per frame
    void Update()
    {
        healthbar.transform.position = healthbarlocation.transform.position;
       
        if (currentHealth == maxHealth)
       {
            healthbar.GetComponent<EnemyHealthBar>().SetColor(Color.green);
        }
        else
        {
            healthbar.GetComponent<EnemyHealthBar>().SetColor(Color.red);
        }

        if(dazedTime <= 0)
        {
            speed = 1f;
        }
        else
        {
            speed = 0f;
            dazedTime -= Time.deltaTime;
        }
        if(waitTime > 0f)
        {
            anim.SetBool("isFollowing", false);
        }

        if (timeBtwAttack <= 0)
        {
            distance = Vector2.Distance(transform.position, playerPoscheck.position);
            if (attackRange >= distance)
            {
                inRange = true;

            }
            else
            {
                inRange = false;
            }

            if (inRange && currentHealth > 0)
            {
                Attack();
                FindObjectOfType<AudioManager>().Play("Rat");
            }
           // else
          //  {
          //      anim.SetBool("isFollowing", true);
          //  }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }


        range = Vector2.Distance(transform.position, playerPoscheck.position);
        
        if (range <= minDistance || currentHealth < maxHealth)
        {
            ChasePlayer();

        }
        else
        {
            MoveSpotFunct();
           
        }

    }
    void Attack()
    {
        anim.SetTrigger("isAttacking");
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, player);
        foreach (Collider2D players in playerToDamage)
        {
            players.GetComponent<Heart>().TakeDamage(-damage);

        }
        timeBtwAttack = startTimeBtwAttack;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }
    void ChasePlayer()
    {
        waitTime = 0f;
        anim.SetBool("isFollowing", true);
        if (playerPos.position.x < transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (playerPos.position.x > transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);


    }
    void MoveSpotFunct()
    {
        anim.SetBool("isFollowing", true);
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (moveSpot.position.x < transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveSpot.position.x > transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                anim.SetBool("isFollowing", true);

                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                if (moveSpot.position.x < transform.position.x)
                {
                    //face right
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (moveSpot.position.x > transform.position.x)
                {
                    //face left
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                waitTime = startwaitTime;
            }
            else
            {
                anim.SetBool("isWaiting", true);
                waitTime -= Time.deltaTime;

            }

        }

    }

    public void TakeDamage(int damage)
    {

        anim.SetTrigger("isHit");
        currentHealthbar -= 10.1333333333f;
        healthbar.GetComponent<EnemyHealthBar>().SetSize(currentHealthbar);
        dazedTime = startDazedTime;
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        currentHealth -= damage;
        Debug.Log("Damage Taken");
        if (currentHealth <= 0)
        {
            healthbar.GetComponent<EnemyHealthBar>().DestroyHealthbar();
            dazedTime = 15f;
            anim.SetTrigger("isDead");
            
            
        }




    }
    public void Destroyrat()
    {
        Destroy(gameObject);

    }
   
        
      
    


}
