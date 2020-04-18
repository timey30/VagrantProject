using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwable : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public GameObject projectile;
    public Transform launchPoint;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("throw");
            timeBtwAttack = startTimeBtwAttack;
            FindObjectOfType<AudioManager>().Play("Throw");
        }
    
    }
    public void stone()
    {
        Instantiate(projectile, launchPoint.position, launchPoint.rotation);
    }
}
