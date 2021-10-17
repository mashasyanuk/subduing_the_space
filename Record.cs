using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour

 {
    public int record;
    public Text scoreText;
    private void Start()
    {
        scoreText.text = "Всего монет :  " + record;
    }
    void Update()
    {
      
        record = PlayerPrefs.GetInt("savescore");
        scoreText.text = "Всего монет :  " + record;

    }

}
