using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }


    public void RestartGame()
    {
        PauseManager.isAutoStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
