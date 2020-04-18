using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combostriker : MonoBehaviour
{
    public Animator anim;
    public int noOFclicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.09f;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time -lastClickedTime > maxComboDelay)
        {
            noOFclicks = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lastClickedTime = Time.time;
            noOFclicks ++;
            if(noOFclicks == 1)
            {
                anim.SetTrigger("Attack");
            }
            noOFclicks = Mathf.Clamp(noOFclicks, 0, 3);

        }

    }
    public void return1()
    {
        if(noOFclicks >= 2)
        {
            anim.SetTrigger("Attack2");
        }
        else
        {
            anim.ResetTrigger("Attack");
            noOFclicks = 0;
        }
    }
    public void return2()
    {
        if (noOFclicks >= 3)
        {
            anim.SetTrigger("Attack3");
        }
        else
        {
            anim.ResetTrigger("Attack2");
            noOFclicks = 0;
        }
    }
    public void return3()
    {

        anim.ResetTrigger("Attack");
        anim.ResetTrigger("Attack2");
        anim.ResetTrigger("Attack3");
        noOFclicks = 0;
        
    }
}
