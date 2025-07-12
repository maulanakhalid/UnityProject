using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    [Header("UI")]
    public TextMeshProUGUI healthText;
    public GameObject GameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();

        if (GameOverPanel != null)
            GameOverPanel.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over!");
            if (GameOverPanel != null)
                GameOverPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1);
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Darah: ♥ " + currentHealth;
        }
        else
        {
            Debug.LogWarning("HealthText belum diisi di Inspector!");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    // Deteksi tabrakan dengan musuh (Collider)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // Musuh memiliki tag "Enemy"
        {
            TakeDamage(1);  // Kurangi 1 health saat tabrakan dengan musuh
        }
    }

    // Atau jika menggunakan Trigger (misalnya collider dengan Is Trigger aktif)
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Enemy"))  // Musuh memiliki tag "Enemy"
    //     {
    //         TakeDamage(1);  // Kurangi 1 health saat melewati trigger musuh
    //     }
    // }
}
