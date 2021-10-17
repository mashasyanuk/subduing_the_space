using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class горячие_клавиши : MonoBehaviour
{
    private int savescore ;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) { //пополнение кошелька
            savescore = PlayerPrefs.GetInt("savescore") + 1000;

            PlayerPrefs.SetInt("savescore", savescore);
        }
        if (Input.GetKeyDown(KeyCode.A)) //горячие клавиши для разработчика , сброс
        {

            PlayerPrefs.SetInt("savescore", 0);
        }
    }
}
