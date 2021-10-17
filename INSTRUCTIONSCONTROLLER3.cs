using UnityEngine;

public class INSTRUCTIONSCONTROLLER3 : MonoBehaviour
{


    public GameObject PauseMenuUI;
    public GameObject PauseMenuUI_main;

    void Start()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
        PauseMenuUI_main.SetActive(false);

    }


    

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        PauseMenuUI_main.SetActive(true);
        Time.timeScale = 1f;
    }
}
