using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour  //портал
{
    private Transform destination;
    public bool isOrange;
    public float destance = 0.3f;
    public AudioSource clip;

    void Start() 
    { if (isOrange == false) //ищет объект пункт-назначения
        {
            destination = GameObject.FindGameObjectWithTag("orangePortal").GetComponent<Transform>(); //находит оранжевый портал

        }
    else
        {
            destination = GameObject.FindGameObjectWithTag("bluePortal").GetComponent<Transform>();//  находит голубой портал
        }

    }

    void OnTriggerEnter2D(Collider2D other) //при столкновении перенос
    {
        if (Vector2.Distance(transform.position, other.transform.position) > destance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            clip.Play();
        }
    }
}
