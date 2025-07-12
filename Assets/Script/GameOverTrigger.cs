using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered Game Over!");
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}