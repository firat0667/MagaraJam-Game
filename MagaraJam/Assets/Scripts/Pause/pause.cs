using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
   public  void GamePause()
    {
        Time.timeScale = 0;
    }
    public void GameReturn()
    {
        Time.timeScale = 1;
    }
}
