using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_generetic : MonoBehaviour
{
    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    float platformWidth;

    public float distanceMin;
    public float distanceMax;
    void Start() //поиск размера объекта
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x) //если положение 
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y , transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
