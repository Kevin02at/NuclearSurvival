using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //check if game is paused
    public static bool GameIsPaused = false; 
    
    public GameObject pauseMenuUI;    
    

    // Update is called once per frame
    void Update()
    {
        //when pressing esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if game is already paused, unpause, else pause
            if (GameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }    
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //unfreeze game 
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //freeze game 
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    
}
