using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Ganti scene langsung dengan nama
    public void ChangeScene(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }

    // Pause game
    public void Paused()
    {
        Time.timeScale = 0f;
    }

    // Lanjutkan game
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    // Retry / Restart level
    public void Retry()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Kembali ke menu utama
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu"); // pastikan nama scene sesuai
    }

    // Muat level berikutnya (Next Level)
    public void NextLevel()
    {
        // Mendapatkan scene saat ini
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = currentScene.buildIndex;

        // Memuat scene berikutnya
        int nextSceneIndex = currentSceneIndex + 1;
        
        // Pastikan scene berikutnya ada di build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Ini adalah level terakhir!");
            // Jika tidak ada level berikutnya, bisa kembali ke menu utama atau semacamnya
            GoToMainMenu();
        }
    }
}
