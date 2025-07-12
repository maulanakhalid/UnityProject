using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the finish!");
            nextLevelUI.SetActive(true);
            Time.timeScale = 0f; // pause game saat selesai
        }
    }
    
}