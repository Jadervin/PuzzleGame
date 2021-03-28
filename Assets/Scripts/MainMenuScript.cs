using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public string startSceneName;
    public string Menu;
    public string Credits;

    public AudioSource soundSource;
    public AudioClip menuClick;

    public float clickTimer = 10;

    public void StartPressed()
    {
        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait(clickTimer));
        SceneManager.LoadScene(startSceneName);
      
    
    
    }
    public void MenuPressed()
    {
        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait(clickTimer));
        SceneManager.LoadScene(Menu);



    }
    public void CreditsPressed()
    {

        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait(clickTimer));
        SceneManager.LoadScene(Credits);



    }
    public void CloseGame()
    {

        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait(clickTimer));
        Application.Quit();


    }

    IEnumerator Wait(float duration)
    {

        yield return new WaitForSeconds(duration);   //Wait

    }

}
