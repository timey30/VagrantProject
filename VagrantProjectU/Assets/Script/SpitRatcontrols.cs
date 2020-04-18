using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitRatcontrols : MonoBehaviour
{
    public Animator anim;
    private Transform playerPos;
    private float minDistance = 2.5f;
    private float range;
    public float speed;
    private float waitTime;
    public float startwaitTime;
    public Transform moveSpot;
   

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


    public float attackRange;
    public LayerMask player;

    private float distance;

    public Transform playerPoscheck;

    public Transform raycast;
    public LayerMask raycastMask;
    public float rayCastLength;
    private RaycastHit2D hit;
    private RaycastHit2D hit2;
    public GameObject Spit;
    public Transform Attackpos;





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




    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth == maxHealth)
        {
            healthbar.GetComponent<EnemyHealthBar>().SetColor(Color.green);
        }
        else
        {
            healthbar.GetComponent<EnemyHealthBar>().SetColor(Color.red);
        }

        if (dazedTime <= 0)
        {
            speed = 1f;
        }
        else
        {
            speed = 0f;
            dazedTime -= Time.deltaTime;
        }
        if (waitTime > 0f)
        {
            anim.SetBool("isFollowing", false);
        }
        hit = Physics2D.Raycast(raycast.position, Vector2.left, rayCastLength, raycastMask);
        hit2 = Physics2D.Raycast(raycast.position, Vector2.right, rayCastLength, raycastMask);
        RaycastDebugger();

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
                if (hit.collider != null || hit2.collider != null)
                {
                    Attack();
                    FindObjectOfType<AudioManager>().Play("SpitRat");
                }
            

            }
            else
            {
                anim.SetBool("isFollowing", false);
            }

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
        
       

    }
    void Attack()
    {
        speed = 0;
        anim.SetTrigger("Spitattack");
        timeBtwAttack = startTimeBtwAttack;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpos.position, attackRange);

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
        if(speed != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        }
       


    }
    

    public void TakeDamage(int damage)
    {

      //  anim.SetTrigger("isHit");
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
            Destroy(gameObject);


        }




    }
    public void Destroyspitrat()
    {
        Destroy(gameObject);

    }
    void RaycastDebugger()
    {
        if (distance > attackRange)
        {
            Debug.DrawRay(raycast.position, Vector2.left * rayCastLength, Color.red);
            Debug.DrawRay(raycast.position, Vector2.right * rayCastLength, Color.red);

        }
        else if (attackRange > distance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * rayCastLength, Color.green);
            Debug.DrawRay(raycast.position, Vector2.right * rayCastLength, Color.green);
        }
    }
    public void spiting()
    {
        Instantiate(Spit, Attackpos.position, Attackpos.rotation);
    }
}
