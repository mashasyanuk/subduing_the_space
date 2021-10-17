using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class highscore : MonoBehaviour
{

    public static int highscore11;
    Text highscore1;

    void Start() //пишем количество набранных монет
    { 
      highscore1.text = "score :" + highscore11 ;
        
    }

}
