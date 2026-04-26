using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        bgmSource.volume = 0.009f;

    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        PauseManager.isAutoStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        PauseManager.isAutoStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
