using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public float waitTime;
    public Animator musicAnim;
   
    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("Fadeout");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene("LevelSelect");
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Level1()
    {
        StartCoroutine(ChangeScene());
        
    }

}
