using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isvisible : MonoBehaviour
{
    public GameObject lvl1;
    public GameObject lvl2;

   public  void check() 
    {
         if (PlayerPrefs.GetInt("ison2") == 1)
            {
                Destroy(lvl1);
            }
       
            if (PlayerPrefs.GetInt("ison3") == 1)
            {
                Destroy(lvl2);
            }
       
    }
}
