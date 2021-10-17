using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levels_game1: MonoBehaviour
{
    public AudioSource clip;

    public void Level1() // переход на сцены при клике на кнопку
    {
        SceneManager.LoadScene(28);
        clip.Play();
    }
    public void Level2()
    {
        SceneManager.LoadScene(29);
        clip.Play();
    }
    public void Level3()
    {
        SceneManager.LoadScene(30);
        clip.Play();
    }
}
