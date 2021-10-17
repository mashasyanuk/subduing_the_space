using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planet_game_2_script_menu : MonoBehaviour //переключение между уровнями
{
    public AudioSource clip;

    public void Level_1()
    {
        SceneManager.LoadScene(31);
        clip.Play();
    }
    public void Level_2()
    {
        SceneManager.LoadScene(32);
        clip.Play();
    }
    public void Level_3()
    {
        SceneManager.LoadScene(33); 
        clip.Play();
    }

}