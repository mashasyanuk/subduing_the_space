using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource clip;
    private void Start() // находим объект
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() //смена гравитации
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            clip.Play();
            rb.gravityScale *= -1;
        }
    }
    
}
