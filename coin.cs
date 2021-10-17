using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

    public AudioSource clip;
    public int savescore;

    void OnTriggerEnter2D(Collider2D col) { // как происходит собирание монет

        score.scoreAmount += 5;

        savescore = PlayerPrefs.GetInt("savescore") + 5;

        PlayerPrefs.SetInt("savescore", savescore);
        PlayerPrefs.Save();
        clip.volume = PlayerPrefs.GetFloat("volume");
        clip.Play();
        Destroy(gameObject);


    }
}
