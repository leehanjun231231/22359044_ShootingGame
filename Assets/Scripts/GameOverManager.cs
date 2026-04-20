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
        bgmSource.volume = 0.1f;

    }


    public void RestartGame()
    {
        PauseManager.isAutoStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
