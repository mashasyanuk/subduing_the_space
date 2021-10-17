using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public AudioSource clip;

   
    public void playAudio () //звук
    {
        clip.Play();
    }
}
