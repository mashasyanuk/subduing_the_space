using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject PauseMenuUI_main;



    void Update() //горячая клавиша 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


     


    }

    private void Pause() //что происходит при нажатии на кнопку паузы
    {
        PauseMenuUI.SetActive(true);
        PauseMenuUI_main.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() //что происходит нажатии на континью
    {
        PauseMenuUI.SetActive(false);
        PauseMenuUI_main.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu() // что происходит при нажатии на кнопку меню
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    
    

}