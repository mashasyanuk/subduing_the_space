using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score2 : MonoBehaviour
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
        scoreText.text = "score :" + scoreAmount;
    }
}
