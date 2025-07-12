using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    private PointManager pointManager;

    private void Start()
    {
        // Mencari objek PointManager di scene
        pointManager = FindObjectOfType<PointManager>();
        if (pointManager == null)
        {
            Debug.LogError("PointManager tidak ditemukan di scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger masuk dengan: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin diambil!");

            if (pointManager != null)
            {
                pointManager.AddPoints(coinValue);
            }
            else
            {
                Debug.LogError("PointManager tidak diassign!");
            }

            Destroy(gameObject);
        }
    }
}
