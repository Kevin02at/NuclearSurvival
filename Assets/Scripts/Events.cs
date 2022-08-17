using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    //restart level
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerManager.currentHealth = 100;
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel (int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        PlayerManager.currentHealth = 100;
        Time.timeScale = 1f;
    }
}
