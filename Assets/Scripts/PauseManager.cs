using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool isAutoStart = false;
    private bool isPaused = false;
    public GameObject pauseUI;
    public AudioSource Button_Audio;

    public Transform spawnPoint;
    public GameObject playerPrefab;


    void Start()
    {
        if (isAutoStart)
        {
            StartGame();
            SpawnPlayer();
            isAutoStart = false;
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseUI.SetActive(true);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void StartGame()
    {

        Time.timeScale = 1f;
        isPaused = false;
        pauseUI.SetActive(false);

    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;

        }
    }

    public void PlayClickSound()
    {
        Button_Audio.Play();
    }

    public void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

}