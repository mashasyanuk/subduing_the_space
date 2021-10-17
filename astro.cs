using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class astro : MonoBehaviour {
public float speed = 20f;
private Rigidbody2D rb;
public float force = 2000f;
public bool faceRight = true ;

    void Start() { // находит объект
       rb = GetComponent <Rigidbody2D> ();
    }

    void Update () { // меняет позицию в пространстве
      
        float moveX = Input.GetAxis ("Horizontal");

       rb.MovePosition (rb.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force);
        }


    }




}
