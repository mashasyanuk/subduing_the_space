using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diespace : MonoBehaviour{ //зона проигрыша

  void OnTriggerEnter2D (Collider2D other) {
  if (other.tag == "Player") {
    SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 3);
       }
     }
}
