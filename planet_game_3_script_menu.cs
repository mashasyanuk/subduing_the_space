using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planet_game_3_script_menu : MonoBehaviour //переключение между уровнями
{
    public AudioSource clip;

    public void Level__1()
    {
        SceneManager.LoadScene(34);
        clip.Play();
    }
    public void Level__2()
    {
        SceneManager.LoadScene(35);
        clip.Play();
    }
    public void Level__3()
    {
        SceneManager.LoadScene(36);
        clip.Play();
    }

}


