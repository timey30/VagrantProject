using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float cooldownTime = 2;
    private float nextFireTime = 0;
    private float speed = 2f;
    public float rollSpeed = 2f;
    Collider2D PCollider;

    public Animator anim;

    

    void Start()
    {
        PCollider = GetComponent<Collider2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {   
        PlMove();
    }

    IEnumerator DashMove()
    {
        anim.Play("Char_Roll");
        FindObjectOfType<AudioManager>().Play("Roll");
        PCollider.enabled = false;
        speed += rollSpeed;
        yield return new WaitForSeconds(.3f);
        speed -= rollSpeed;
        PCollider.enabled = true;
    }


    void PlMove()
    {

        
        float moveX = 0f;
        float moveY = 0f;

        

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
            FindObjectOfType<AudioManager>().Play("Footsteps");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
            FindObjectOfType<AudioManager>().Play("Footsteps");
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
            FindObjectOfType<AudioManager>().Play("Footsteps");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
            FindObjectOfType<AudioManager>().Play("Footsteps");
        }

        if (Time.time > nextFireTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine("DashMove");
                print("ability used, cooldown started");
                StartCoroutine("DashMove");
                
                nextFireTime = Time.time + cooldownTime;
            }
        }
        
        anim.SetFloat("speed", Mathf.Abs(moveX));
        anim.SetFloat("height", Mathf.Abs(moveY));

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;

        Vector3 characterScale = transform.localScale;
        if (moveX < 0)
        {

            characterScale.x = -1;

        }
        if (moveX > 0)
        {

            characterScale.x = 1;

        }
        transform.localScale = characterScale;
    }

}
