using UnityEngine;
using UnityEngine.SceneManagement;

public class back_to_loose : MonoBehaviour {


void OnTriggerEnter2D (Collider2D other) { // при наступании на триггер перенос на другую сцену
if (other.tag == "Player") {
   SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 3);
}
}
}
