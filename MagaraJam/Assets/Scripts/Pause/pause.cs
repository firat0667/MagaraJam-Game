using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            
        }
    }
    //public void PauseGame()
    //{
    //    Time.timeScale = 0f;
    //}
    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }
}
