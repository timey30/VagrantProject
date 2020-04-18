using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialDodge : MonoBehaviour
{
    [SerializeField] private Image TutDog;
    [SerializeField] private GameObject TutDogUI1;
    [SerializeField] private GameObject TutDogUI2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TutDog.enabled = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TutDogUI2.SetActive(false);
            Update();
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TutDog.enabled = false;
            TutDogUI1.SetActive(false);
            
        }

    }

   
}
