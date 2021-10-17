
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_to_win : MonoBehaviour {


void OnTriggerEnter2D (Collider2D other)  { // при наступании на триггер перенос на другую сцену
        if (other.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
}
}
}

