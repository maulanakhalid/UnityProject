using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthUI health = FindObjectOfType<HealthUI>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
                Debug.Log("Player kena musuh! HP berkurang.");
            }
        }
    }
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Y))
    {
        FindObjectOfType<HealthUI>().TakeDamage(damageAmount);
    }
}

}
