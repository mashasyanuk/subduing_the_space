using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject destroyPoint;

    void Start() //нахоим пустой обьект
    {
        destroyPoint = GameObject.Find("DestroyPoint");
    }

    void Update() //если край платформы вышел на пределы камеры, его удаляем
    {
        if (transform.position.x < destroyPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
