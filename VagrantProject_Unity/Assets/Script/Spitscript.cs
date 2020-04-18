using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitscript : MonoBehaviour
{

    public float speed;
    public float lifeTIme;
    private GameObject enemy;
    // public GameObject enemy2;
    private Transform enemyPos;
    public GameObject player;
    public Vector3 enemyTransform;


    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTIme);
        enemy = GameObject.FindGameObjectWithTag("SptRat");
        enemyTransform = enemy.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyTransform == new Vector3(1, 1, 1))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (enemyTransform == new Vector3(-1, 1, 1))
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
        if (trig.gameObject.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Heart>().TakeDamage(-damage);
            speed = 0;
            DestroyProjectile();

        }
       
    }
}
