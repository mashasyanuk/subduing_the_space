using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicSettings : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    public Text musicvolume;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        PlayerPrefs.SetFloat("volume", 1f);

    }

    void Update()
    {
        audioSrc.volume = musicVolume;
        musicvolume.text = "Музыка : " + string.Format("{0:0}%", musicVolume * 100);
        PlayerPrefs.SetFloat("volume", musicVolume);

    }
    public void SetVolume (float vol)
    {
        musicVolume = vol;
    }
}
