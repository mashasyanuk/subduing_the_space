using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private Transform destination;
    public bool isOrange;
    public float destance = 0.3f;
    public AudioSource clip;

    void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("orangePortal2").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("bluePortal2").GetComponent<Transform>();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > destance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            clip.Play();
        }
    }
}
