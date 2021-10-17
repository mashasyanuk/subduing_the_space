using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lockedLevels : MonoBehaviour
{

    public Button firstlockedUI;
    public Button secondlockedUI;
    private int record;
    public AudioSource clip;
    public AudioSource clip1;


    void Start()
    {
        record = PlayerPrefs.GetInt("savescore");


    }

    public void planet2_locked()
    {
        if (record < 300 )
        {
            clip.Play();
        }
        else if (record >= 300)
        {

           

           clip1.Play();

            record = PlayerPrefs.GetInt("savescore") - 300 ;

            PlayerPrefs.SetInt("savescore", record);
            PlayerPrefs.SetInt("2locked", 1);
            firstlockedUI.gameObject.SetActive(false);
          
        }
    }

    public void BeActive2()
    {
        if (PlayerPrefs.GetInt("2locked") == 1)
        {
            firstlockedUI.gameObject.SetActive(false);
            Debug.Log(PlayerPrefs.GetInt("2locked"));
        }
    }

    public void planet3_locked()
    {

        if (record < 600 ) 
        {
            clip.Play();
        }
        else if (record >= 600 )
        {
            clip1.Play();


            record = PlayerPrefs.GetInt("savescore") - 600;

            PlayerPrefs.SetInt("savescore", record);
            secondlockedUI.gameObject.SetActive(false);
            PlayerPrefs.SetInt("3locked", 1); // open


        }
    }
   
    public void BeActive3()
    {
        if (PlayerPrefs.GetInt("3locked") == 1)
        {
            secondlockedUI.gameObject.SetActive(false);
            Debug.Log(PlayerPrefs.GetInt("3locked"));
        }
    }

}
