using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDodgePart2 : MonoBehaviour
{
    
    [SerializeField] private GameObject TutDogUI1;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        TutDogUI1.SetActive(true);

    }

}
