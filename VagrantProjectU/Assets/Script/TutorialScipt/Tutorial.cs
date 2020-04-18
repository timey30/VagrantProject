using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image TutMov;
    [SerializeField] private GameObject TutMovUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TutMov.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TutMov.enabled = false;
            TutMovUI.SetActive(false);
        }
    } 

   
}


