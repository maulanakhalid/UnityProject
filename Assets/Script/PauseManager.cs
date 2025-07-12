using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    public GameObject Pause;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
{
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;

    if (Pause != null)
        Pause.SetActive(true); // tampilkan tombol pause lagi
}

public void PauseGame()
{
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;

    if (Pause != null)
        Pause.SetActive(false); // sembunyikan tombol pause saat game dipause
}


    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }
}
