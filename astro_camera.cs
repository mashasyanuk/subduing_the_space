using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class astro_camera : MonoBehaviour
{
    public float speedup = 10f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;


    void Start() // получает объект
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() // как происходит движение
    {
        Vector2 moveInput = new Vector2(0f, 1f);
        moveVelocity = moveInput.normalized * speedup;

        if (Input.GetKey(KeyCode.Tab)) // ускорение
        {
            speedup = 30f;


        }
        else
        {
            speedup = 10f;
        }

    }


    void FixedUpdate() // плавное движение
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }





}

