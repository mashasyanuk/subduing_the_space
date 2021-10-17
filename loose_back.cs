using UnityEngine;
using UnityEngine.SceneManagement;

public class loose_back : MonoBehaviour {

 public void restart(){ //перезапуск игры
   SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 3);
}
 public void stop(){ // переход в главное меню
   SceneManager.LoadScene (37);
}
}
