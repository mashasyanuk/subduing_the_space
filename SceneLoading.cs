using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoading : MonoBehaviour
{
    public int sceneID;

    public Image loadingImg;

    public Text ProgressText;

    private float timer;


    void Start()
    {
        loadingImg.fillAmount = 0;
    }

    void Update()
    {
            timer += 5 * Time.deltaTime;

            if (timer >= 2 )
            {
                 loadingImg.fillAmount +=0.18f;
                 ProgressText.text = string.Format("{0:0}%", loadingImg.fillAmount * 100);

                 timer = 0; ;
            }
       
        if (loadingImg.fillAmount == 1)
        {
           SceneManager.LoadScene(sceneID);
        }
        
    }
}
