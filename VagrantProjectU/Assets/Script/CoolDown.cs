using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public float cooldownTime = 2;
    private float nextFireTime = 0;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("ability used, cooldown started");
                nextFireTime = Time.time + cooldownTime;
            }
        }
       
    }
   

}
