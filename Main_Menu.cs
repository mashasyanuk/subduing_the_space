using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour {
    public AudioSource clip;

    public Button firstlockedUI;
    public Button secondlockedUI;


    public void Planet1(){ //что происходит при нажимании какой-то игры
   SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        clip.Play();
}
 public void Planet2(){
    SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 2);
        clip.Play();
    }
 public void Planet3(){
    SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 3);
        clip.Play();
    }
 public void QuitGame(){ // выход из игры
   Debug.Log("Quit");
   Application.Quit();
}
    public void Reset1() //сброс настроек
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("savescore", 0);
        PlayerPrefs.SetFloat("volume", 1f);
        PlayerPrefs.SetInt("2locked", 0);
        PlayerPrefs.SetInt("3locked", 0);
        firstlockedUI.gameObject.SetActive(true);
        secondlockedUI.gameObject.SetActive(true);
    }
}
