using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int scoreAmount;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;

    }

    void Update()
    {
        scoreText.text = "Монет набрано :  " + scoreAmount;
    }
}
