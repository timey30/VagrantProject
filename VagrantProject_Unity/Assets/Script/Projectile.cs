using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTIme;
    private GameObject enemy;
   // public GameObject enemy2;
    private Transform enemyPos;
    public GameObject player;
    public Vector3 playerTransform;


    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTIme);
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {
       
         if (playerTransform == new Vector3(1,1,1))
         {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
         else if (playerTransform == new Vector3(-1, 1, 1))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
      
       
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D trig)

    {
        if (trig.gameObject.tag == "MiniRat")
        {
            enemy = GameObject.FindGameObjectWithTag("MiniRat");
            enemy.GetComponent<ratcontrols>().TakeDamage(damage);
            speed = 0;
            DestroyProjectile();

        }else if (trig.gameObject.tag == "SptRat")
        {
            enemy = GameObject.FindGameObjectWithTag("SptRat");
            enemy.GetComponent<SpitRatcontrols>().TakeDamage(damage);
            speed = 0;
            DestroyProjectile();
        }
    }
}
